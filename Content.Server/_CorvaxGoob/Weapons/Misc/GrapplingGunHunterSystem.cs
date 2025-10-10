using System;
using Content.Server.Stunnable;
using Content.Shared._CorvaxGoob.Weapons.Misc;
using Content.Shared._CorvaxGoob.Weapons.Ranged.Components;
using Content.Shared.StatusEffect;

namespace Content.Server._CorvaxGoob.Weapons.Misc;

public sealed class GrapplingGunHunterSystem : SharedGrapplingGunHunterSystem
{
    [Dependency] private readonly StunSystem _stun = default!;

    private static readonly TimeSpan StunDuration = TimeSpan.FromSeconds(1);

    protected override void TryApplyHookStun(EntityUid target, GrapplingGunHunterComponent component, EntityUid? shooter)
    {
        if (!TryComp<StatusEffectsComponent>(target, out var status))
            return;

        _stun.TryKnockdown(target, StunDuration, true, status);
        _stun.TryStun(target, StunDuration, true, status);
    }
}
