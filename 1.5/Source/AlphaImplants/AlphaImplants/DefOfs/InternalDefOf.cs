using System;
using RimWorld;
using Verse;
using System.Collections.Generic;

namespace AlphaImplants
{
    [DefOf]
    public static class InternalDefOf
    {
        static InternalDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(InternalDefOf));
        }



    }
}
