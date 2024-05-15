using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace AlphaImplants
{
    public class HediffImplantExtension : DefModExtension
    {
        public List<BodyPartGroupDef> bodyPartGroupsToMultiplyDamage;
        public float powerMultiplier = 1;
        public float cooldownTimeMultiplier = 1;



    }
}
