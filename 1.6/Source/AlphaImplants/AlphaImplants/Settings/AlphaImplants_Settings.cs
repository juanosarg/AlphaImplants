using RimWorld;
using UnityEngine;
using Verse;
using System;


namespace AlphaImplants
{


    public class AlphaImplants_Settings : ModSettings

    {


        public static float prostheticBodyLimit = prostheticBodyLimitBase;
        public const float prostheticBodyLimitBase = 0.5f;

        public static float bionicBodyLimit = bionicBodyLimitBase;
        public const float bionicBodyLimitBase = 1f;

        public static float archotechBodyLimit = archotechBodyLimitBase;
        public const float archotechBodyLimitBase = 2f;



        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref prostheticBodyLimit, "prostheticBodyLimit", prostheticBodyLimitBase, true);
            Scribe_Values.Look(ref bionicBodyLimit, "bionicBodyLimit", bionicBodyLimitBase, true);
            Scribe_Values.Look(ref archotechBodyLimit, "archotechBodyLimit", archotechBodyLimitBase, true);
          
        }

        public static void DoWindowContents(Rect inRect)
        {
            Listing_Standard ls2 = new Listing_Standard();


            ls2.Begin(inRect);

            var prostheticLabel = ls2.LabelPlusButton("AI_ProstheticBodyLimit".Translate() + ": " + prostheticBodyLimit, "AI_ProstheticBodyLimitTooltip".Translate());
            prostheticBodyLimit = (float)Math.Round(ls2.Slider(prostheticBodyLimit, 0, 3), 2);

            if (ls2.Settings_Button("AI_Reset".Translate() + " " + "AI_ProstheticBodyLimit".Translate(), new Rect(0f, prostheticLabel.position.y + 35, 250f, 29f)))
            {
                prostheticBodyLimit = prostheticBodyLimitBase;
            }

            var bionicLabel = ls2.LabelPlusButton("AI_BionicBodyLimit".Translate() + ": " + bionicBodyLimit, "AI_BionicBodyLimitTooltip".Translate());
            bionicBodyLimit = (float)Math.Round(ls2.Slider(bionicBodyLimit, prostheticBodyLimit, 3), 2);

            if (ls2.Settings_Button("AI_Reset".Translate() + " " + "AI_BionicBodyLimit".Translate(), new Rect(0f, bionicLabel.position.y + 35, 250f, 29f)))
            {
                bionicBodyLimit = bionicBodyLimitBase;
            }

            var archotechLabel = ls2.LabelPlusButton("AI_ArchotechBodyLimit".Translate() + ": " + archotechBodyLimit, "AI_ArchotechBodyLimitTooltip".Translate());
            archotechBodyLimit = (float)Math.Round(ls2.Slider(archotechBodyLimit, bionicBodyLimit, 3), 2);

            if (ls2.Settings_Button("AI_Reset".Translate() + " " + "AI_ArchotechBodyLimit".Translate(), new Rect(0f, archotechLabel.position.y + 35, 250f, 29f)))
            {
                archotechBodyLimit = archotechBodyLimitBase;
            }

            ls2.End();
        }



    }










}
