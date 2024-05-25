
using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;
using Verse.Sound;
namespace AlphaImplants
{
    public class CompAbilityEffect_SelfSkip : CompAbilityEffect_Teleport
    {
      
        public new CompProperties_AbilityTeleport Props => (CompProperties_AbilityTeleport)props;

        public override string ExtraLabelMouseAttachment(LocalTargetInfo target)
        {
            return CanSkipTarget(target).Reason;
        }

        private AcceptanceReport CanSkipTarget(LocalTargetInfo target)
        {
            Pawn pawn;
            if ((pawn = target.Thing as Pawn) != null)
            {
                if (pawn.BodySize > Props.maxBodySize)
                {
                    return "CannotSkipTargetTooLarge".Translate();
                }
                if (pawn.kindDef.skipResistant)
                {
                    return "CannotSkipTargetPsychicResistant".Translate();
                }
                if (parent.pawn != pawn)
                {
                    return "AI_NeedToTargetCaster".Translate();
                }
            }
            return true;
        }


    }
}