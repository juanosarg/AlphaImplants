using RimWorld;
using UnityEngine;
using Verse;


namespace AlphaImplants
{



    public class AlphaImplants_Mod : Mod
    {

        public AlphaImplants_Mod(ModContentPack content) : base(content)
        {
            GetSettings<AlphaImplants_Settings>();
        }
        public override string SettingsCategory()
        {
            return "Alpha Implants";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            AlphaImplants_Settings.DoWindowContents(inRect);
        }
    }


}
