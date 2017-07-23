using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace Kennen.D
{
    internal partial class Program
    {
        private static void OnHarass()
        {
            if (Q.Ready &&
                Harass["harassQ"].As<MenuBool>().Enabled)
            {
                var heroTarget = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);
                if (heroTarget.IsValidTarget() &&
                    !Invulnerable.Check(heroTarget, DamageType.Magical))
                    Q.Cast(heroTarget);
            }

            if (W.Ready && Harass["harassW"].As<MenuBool>().Enabled)
                foreach (var objAiHero in GameObjects.EnemyHeroes)
                    if (objAiHero.IsValidTarget(W.Range) && !Invulnerable.Check(objAiHero, DamageType.Magical))
                    {
                        var Buffs = objAiHero.Buffs;
                        foreach (var Buff in Buffs)
                            if (Buff.Name == "kennenmarkofstorm")
                            {
                                W.Cast();
                                break;
                            }
                    }
        }
    }
}