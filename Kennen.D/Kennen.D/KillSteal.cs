using Aimtec;
using Aimtec.SDK.Damage;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace Kennen.D
{
    internal partial class Program
    {
        private static void OnKillSteal()
        {
            if (W.Ready &&
                KillSteal["killStealW"].As<MenuBool>().Enabled)
                foreach (var objAiHero in GameObjects.EnemyHeroes)
                    if (objAiHero.IsValidTarget(W.Range) && !Invulnerable.Check(objAiHero, DamageType.Magical) &&
                        Player.GetSpellDamage(objAiHero, SpellSlot.W) > objAiHero.Health)
                    {
                        var Buffs = objAiHero.Buffs;
                        foreach (var Buff in Buffs)
                            if (Buff.Name == "kennenmarkofstorm")
                            {
                                W.Cast();
                                break;
                            }
                    }

            if (Q.Ready &&
                KillSteal["killStealQ"].As<MenuBool>().Enabled)
            {
                var bestTarget = Q.GetBestKillableHero(DamageType.Magical);
                if (bestTarget != null &&
                    Player.GetSpellDamage(bestTarget, SpellSlot.Q) > bestTarget.Health)
                    Q.Cast(bestTarget);
            }

            if (R.Ready &&
                KillSteal["killStealR"].As<MenuBool>().Enabled)
            {
                var Count = 0;
                var Killable = false;
                foreach (var objAiHero in GameObjects.EnemyHeroes)
                    if (objAiHero.IsValidTarget(RManager["rRange"].As<MenuSlider>().Value) &&
                        !Invulnerable.Check(objAiHero, DamageType.Magical))
                    {
                        if (Player.GetSpellDamage(objAiHero, SpellSlot.R) > objAiHero.Health)
                            Killable = true;
                        Count++;
                    }
                if (Count >= KillSteal["killStealMin"].As<MenuSlider>().Value && Killable)
                    R.Cast();
            }
        }
    }
}