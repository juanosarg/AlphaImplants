using System.Collections.Generic;
using System.Linq;
using Verse;

namespace VFECore
{
    [StaticConstructorOnStartup]
    public static class AlphaImplants
    {
       

        static AlphaImplants()
        {
            List<ThingDef> allDefsListForReading = DefDatabase<ThingDef>.AllDefsListForReading;
            for (int j = 0; j < allDefsListForReading.Count; j++)
            {
                List<RecipeDef> listForRefresh = allDefsListForReading[j].AllRecipes;
            }
        }
    }
}