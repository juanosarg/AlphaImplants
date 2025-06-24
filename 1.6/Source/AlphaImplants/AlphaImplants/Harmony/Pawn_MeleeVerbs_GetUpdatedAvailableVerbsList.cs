using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Verse.AI;

namespace AlphaImplants
{

    [HarmonyPatch(typeof(HediffComp_VerbGiver))]
    [HarmonyPatch("Tools", MethodType.Getter)]

   
    public static class AlphaImplants_HediffComp_VerbGiver_Tools_Patch
    {
        [HarmonyPostfix]
        public static void MultiplyToolPower(HediffComp_VerbGiver __instance, List<Tool> __result)

        {
            if (__instance.parent.def.GetModExtension<HediffImplantExtension>() != null)
            {
                HediffImplantExtension extension = __instance.parent.def.GetModExtension<HediffImplantExtension>();
                List<Tool> multipliedTools = new List<Tool>();
                foreach (Tool tool in __result)
                {
                    Pawn pawn = __instance.parent.pawn;
                    Tool originalTool = pawn.Tools?.Where(x => extension.bodyPartGroupsToMultiplyDamage.Contains(x.linkedBodyPartsGroup)).RandomElement();

                    float powerBase = originalTool != null ? originalTool.power : 1;
                    float cooldownBase = originalTool != null ? originalTool.cooldownTime : 1;

                    Tool tool2 = tool;
                    tool2.power = powerBase * extension.powerMultiplier;
                    tool2.cooldownTime = cooldownBase * extension.cooldownTimeMultiplier;
                    multipliedTools.Add(tool2);

                }
                __result= multipliedTools;
            }
           

        }

       

    }
}
