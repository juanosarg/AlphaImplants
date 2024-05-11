using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Verse.AI;
using RimWorld.Planet;


namespace AlphaImplants
{


    [HarmonyPatch(typeof(ThingDef))]
    [HarmonyPatch("AllRecipes", MethodType.Getter)]
    public static class AnimalImplants_Thing_AllRecipes
    {

        private static List<RecipeDef> allRecipesCachedInternal;

        [HarmonyPostfix]
        public static IEnumerable<RecipeDef> SelectRecipeTargets(IEnumerable<RecipeDef> values, ThingDef __instance, List<RecipeDef> ___allRecipesCached)
        {
           
            if (allRecipesCachedInternal is null)
            {
                allRecipesCachedInternal = new List<RecipeDef>();
                List<RecipeDef> resultingList = values.ToList();
                
                List<RecipeDef> allDefsListForReading = DefDatabase<RecipeDef>.AllDefsListForReading;
                for (int j = 0; j < allDefsListForReading.Count; j++)
                {
                    if (allDefsListForReading[j].defName.Contains("AI_Crude_"))
                    {

                        resultingList.Add(allDefsListForReading[j]);
                    }
                    if (allDefsListForReading[j].defName.Contains("AI_Prosthetic_") && __instance.race?.baseBodySize>=0.5f)
                    {
                       
                        resultingList.Add(allDefsListForReading[j]);
                    }
                    if (allDefsListForReading[j].defName.Contains("AI_Bionic_") && __instance.race?.baseBodySize >= 1f)
                    {

                        resultingList.Add(allDefsListForReading[j]);
                    }
                }
                foreach(var item in resultingList)
                {
                    allRecipesCachedInternal.Add(item);
                }

              
            }
            return allRecipesCachedInternal;
         
        }
    }
}
