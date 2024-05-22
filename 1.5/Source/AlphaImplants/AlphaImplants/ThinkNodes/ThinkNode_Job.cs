
using AlphaImplants;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace AlphaImplants
{
    public class ThinkNode_FlickJob : ThinkNode_Conditional
    {
        public string jobToCheck;

        protected override bool Satisfied(Pawn pawn)
        {
            if (StaticCollectionsClass.pawn_and_jobgivers[pawn].Contains(jobToCheck))
            {
                return true;
            }
            return false;
        }
    }
}
