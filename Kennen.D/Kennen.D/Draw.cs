using System.Drawing;
using Aimtec;
using Aimtec.SDK.Menu.Components;

namespace Kennen.D
{
    internal partial class Program
    {
        private static void OnDraw()
        {
            if (!Draw["drawReady"].As<MenuBool>().Enabled)
            {
                if (Draw["drawQ"].As<MenuBool>().Enabled)
                    Render.Circle(Player.Position, Q.Range, 50, Color.Blue);
                if (Draw["drawW"].As<MenuBool>().Enabled)
                    Render.Circle(Player.Position, W.Range, 50, Color.White);
                if (Draw["drawR"].As<MenuBool>().Enabled)
                    Render.Circle(Player.Position, RManager["rRange"].As<MenuSlider>().Value, 50, Color.Red);
            }
            else
            {
                if (Draw["drawQ"].As<MenuBool>().Enabled && Q.Ready)
                    Render.Circle(Player.Position, Q.Range, 50, Color.Blue);
                if (Draw["drawW"].As<MenuBool>().Enabled && W.Ready)
                    Render.Circle(Player.Position, W.Range, 50, Color.White);
                if (Draw["drawR"].As<MenuBool>().Enabled && R.Ready)
                    Render.Circle(Player.Position, RManager["rRange"].As<MenuSlider>().Value, 50, Color.Red);
            }
        }
    }
}