
using AlphaImplants;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace AlphaImplants
{
    public class ThinkNode_WorkingAnimal : ThinkNode_Conditional
    {


        protected override bool Satisfied(Pawn pawn)
        {
            if (StaticCollectionsClass.pawn_and_jobgivers.ContainsKey(pawn))
            {
                return true;
            }
            return false;
        }
    }
}
