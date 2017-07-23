using Aimtec;
using Aimtec.SDK.Events;
using Aimtec.SDK.Menu.Components;
using Aimtec.SDK.Orbwalking;

namespace Kennen.D
{
    internal partial class Program
    {
        public static Orbwalker Orbwalker;
        public static Obj_AI_Hero Player;

        private static void Main()
        {
            GameEvents.GameStart += OnStart;
        }

        private static void OnStart()
        {
            Player = ObjectManager.GetLocalPlayer();
            if (Player.ChampionName != "Kennen")
                return;
            Orbwalker = new Orbwalker();
            Menu();
            Spells();
            Render.OnPresent += OnDraw;
            Game.OnUpdate += OnUpdate;
        }

        private static void OnUpdate()
        {
            if (Player.IsDead)
                return;
            OnKillSteal();
            switch (Orbwalker.Mode)
            {
                case OrbwalkingMode.Combo:
                    OnCombo();
                    break;
                case OrbwalkingMode.Mixed:
                    OnHarass();
                    break;
            }
            if (Harass["harassAutoKey"].As<MenuKeyBind>().Enabled && Orbwalker.Mode != OrbwalkingMode.Mixed)
                OnHarass();
            if (Flee["fleeKey"].As<MenuKeyBind>().Enabled)
                OnFlee();
            if (RManager["autoR"].As<MenuBool>().Enabled && CheckR())
                R.Cast();
        }
    }
}