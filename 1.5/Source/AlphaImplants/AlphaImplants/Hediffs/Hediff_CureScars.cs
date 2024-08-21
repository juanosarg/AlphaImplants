using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace AlphaImplants
{
    public class Hediff_CureScars : Hediff
    {

        public override void PostMake()
        {
            base.PostMake();

            Hediff hediff = null;
            List<BodyPartRecord> parts = new List<BodyPartRecord>() { this.Part};
            hediff = Util.FindPermanentInjury(pawn, parts);
            while(hediff != null)
            {
                HealthUtility.Cure(hediff);
                hediff = Util.FindPermanentInjury(pawn, parts);
            }

        }





    }


}

