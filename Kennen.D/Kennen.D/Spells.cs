using Aimtec;
using Aimtec.SDK.Prediction.Skillshots;
using Spell = Aimtec.SDK.Spell;

namespace Kennen.D
{
    internal partial class Program
    {
        public static Spell Q, W, E, R;

        private static void Spells()
        {
            Q = new Spell(SpellSlot.Q, 1050);
            W = new Spell(SpellSlot.W, 725);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R);

            Q.SetSkillshot(0.25f, 50, 1700, true, SkillshotType.Line);
        }
    }
}