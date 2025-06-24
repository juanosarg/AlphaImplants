
using Verse;
using System;
using RimWorld;
using System.Collections.Generic;
using System.Linq;


namespace AlphaImplants
{
    [StaticConstructorOnStartup]
    public static class StaticCollectionsClass
    {


        public static Dictionary<HediffDef, float> hediffs_and_health_modifiers = new Dictionary<HediffDef, float>();
        public static Dictionary<Pawn, List<string>> pawn_and_jobgivers = new Dictionary<Pawn, List<string>>();

        static StaticCollectionsClass()
        {

            List<HediffDef> allHediffs = DefDatabase<HediffDef>.AllDefsListForReading.Where(x => x.HasModExtension<HealthModifierExtension>()).ToList();
            foreach (HediffDef hediff in allHediffs)
            {

                HealthModifierExtension extension = hediff.GetModExtension<HealthModifierExtension>();
                hediffs_and_health_modifiers.Add(hediff, extension.healthPointToAdd);
            }

        }

        public static void AddPawnAndJobgiver(Pawn pawn, string jobgiver)
        {
            if (!pawn_and_jobgivers.ContainsKey(pawn))
            {
                pawn_and_jobgivers.Add(pawn, new List<string> { jobgiver});
            }
            else if (!pawn_and_jobgivers[pawn].Contains(jobgiver))
            {
                pawn_and_jobgivers[pawn].Add(jobgiver);
            }
        }

        public static void RemovePawnAndJobgiver(Pawn pawn, string jobgiver)
        {
            if (pawn_and_jobgivers.ContainsKey(pawn))
            {
                if (pawn_and_jobgivers[pawn].Contains(jobgiver))
                {
                    pawn_and_jobgivers[pawn].Remove(jobgiver);
                }
            }
           

        }
        public static void RemovePawnOutright(Pawn pawn)
        {
            if (pawn_and_jobgivers.ContainsKey(pawn))
            {
                pawn_and_jobgivers.Remove(pawn);
            }


        }




    }
}
