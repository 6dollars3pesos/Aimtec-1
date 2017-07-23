using Aimtec;
using Aimtec.SDK.Extensions;
using Aimtec.SDK.Menu.Components;

namespace Kennen.D
{
    internal partial class Program
    {
        private static void OnFlee()
        {
            Player.IssueOrder(OrderType.MoveTo, Game.CursorPos);

            if (E.Ready && Flee["fleeE"].As<MenuBool>().Enabled && !Player.HasBuff("KennenLightningRush"))
                E.Cast();
        }
    }
}