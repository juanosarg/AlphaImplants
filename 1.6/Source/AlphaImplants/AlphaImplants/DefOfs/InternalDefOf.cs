using System;
using RimWorld;
using Verse;
using System.Collections.Generic;
using Verse.AI;

namespace AlphaImplants
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }

        public static JobDef AI_AnimalHuntJob;
        public static JobDef AI_AnimalHarvestJob;

        [MayRequireAnomaly]
        public static AnimationDef ShamblerSway;

        public static WorkGiverDef GrowerSow;
        public static WorkGiverDef Mine;

        public static RecipeDef AI_AnimalEnlarger;
        public static RecipeDef AI_AnimalShrinker;

    }
}
