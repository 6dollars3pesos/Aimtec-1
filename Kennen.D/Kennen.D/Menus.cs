using System.Linq;
using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Util;
using Aimtec.SDK.Util.Cache;

namespace Kennen.D
{
    internal partial class Program
    {
        public static Menu Root;
        public static Menu Combo;
        public static Menu RManager;
        public static Menu Flee;

        public static Menu Harass;

        //public static Menu LastHit;
        public static Menu KillSteal;

        public static Menu Draw;

        private static void Menu()
        {
            Root = new Menu("Kennen", "Kennen.D", true);
            Orbwalker.Attach(Root);

            Combo = new Menu("combo", "Combo")
            {
                new MenuBool("comboQ", "Use Q"),
                new MenuBool("comboW", "Use W"),
                new MenuBool("comboR", "Use R")
            };
            Root.Add(Combo);

            RManager = new Menu("rManager", "R Manager")
            {
                new MenuBool("autoR", "Auto R"),
                new MenuSlider("rRange", "R Range -> ", 480, 1, 550),
                new MenuSlider("minR", "Minimum score -> ", 1, 1, GameObjects.EnemyHeroes.Count() * 3),
                new MenuSeperator("")
            };
            foreach (var objAiHero in GameObjects.EnemyHeroes)
                RManager.Add(new MenuSlider(objAiHero.NetworkId.ToString(), objAiHero.ChampionName + " -> ", 1, 1, 3));
            Root.Add(RManager);

            Flee = new Menu("flee", "Flee")
            {
                new MenuBool("fleeE", "Use E"),
                new MenuKeyBind("fleeKey", "Flee Key -> ", KeyCode.W, KeybindType.Press)
            };
            Root.Add(Flee);

            Harass = new Menu("harass", "Harass")
            {
                new MenuBool("harassQ", "Use Q"),
                new MenuBool("harassW", "Use W"),
                new MenuKeyBind("harassAutoKey", "Auto Harass Key -> ", KeyCode.T, KeybindType.Toggle)
            };
            Root.Add(Harass);

            /*
            LastHit = new Menu("lastHit", "LastHit")
            {
                new MenuBool("lastHitQ", "Use Q"),
                new MenuBool("lastHitW", "Use W")
            };
            Root.Add(LastHit);
            */

            KillSteal = new Menu("killSteal", "KillSteal")
            {
                new MenuBool("killStealQ", "Use Q"),
                new MenuBool("killStealW", "Use W"),
                new MenuBool("killStealR", "Use R"),
                new MenuSlider("killStealMin", "Min to Hit With R -> ", 1, 1, GameObjects.EnemyHeroes.Count())
            };
            Root.Add(KillSteal);

            Draw = new Menu("draw", "Draw")
            {
                new MenuBool("drawQ", "Draw Q"),
                new MenuBool("drawW", "Draw W"),
                new MenuBool("drawR", "Draw R"),
                new MenuBool("drawReady", "Disable on CD")
            };
            Root.Add(Draw);

            Root.Attach();
        }
    }
}