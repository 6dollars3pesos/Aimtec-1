using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util.Cache;

namespace Kennen.D
{
    internal partial class Program
    {
        private static void OnCombo()
        {
            if (Q.Ready &&
                Combo["comboQ"].As<MenuBool>().Enabled)
            {
                var heroTarget = Extensions.GetBestEnemyHeroTargetInRange(Q.Range);
                if (heroTarget.IsValidTarget() &&
                    !Invulnerable.Check(heroTarget, DamageType.Magical))
                    Q.Cast(heroTarget);
            }

            if (W.Ready && Combo["comboW"].As<MenuBool>().Enabled)
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

            if (R.Ready &&
                Combo["comboR"].As<MenuBool>().Enabled && CheckR() && !RManager["autoR"].As<MenuBool>().Enabled)
                R.Cast();
        }

        private static bool CheckR()
        {
            var Count = 0;
            foreach (var objAiHero in GameObjects.EnemyHeroes)
                if (objAiHero.IsValidTarget(RManager["rRange"].As<MenuSlider>().Value) &&
                    !Invulnerable.Check(objAiHero, DamageType.Magical))
                    Count += RManager[objAiHero.NetworkId.ToString()].As<MenuSlider>().Value;
            if (Count >= RManager["minR"].As<MenuSlider>().Value)
                return true;
            return false;
        }
    }
}