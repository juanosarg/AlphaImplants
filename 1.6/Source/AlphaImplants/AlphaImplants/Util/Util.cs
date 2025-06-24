using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace AlphaImplants
{
    public class Util 
    {       

        public static Hediff_Injury FindPermanentInjury(Pawn pawn, IEnumerable<BodyPartRecord> allowedBodyParts = null)
        {
            Hediff_Injury hediff_Injury = null;
            List<Hediff> hediffs = pawn.health.hediffSet.hediffs;
            for (int i = 0; i < hediffs.Count; i++)
            {
                Hediff_Injury hediff_Injury2 = hediffs[i] as Hediff_Injury;
                if (hediff_Injury2 != null && hediff_Injury2.Visible && hediff_Injury2.IsPermanent() 
                    && hediff_Injury2.def.everCurableByItem && (allowedBodyParts == null || allowedBodyParts.Contains(hediff_Injury2.Part)))
                {
                    hediff_Injury = hediff_Injury2;
                }
            }
            return hediff_Injury;
        }


    }


}

