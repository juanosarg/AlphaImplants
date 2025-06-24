﻿using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace AlphaImplants
{
    public class Recipe_InstallArtificialBodyPart_Archotech : Recipe_InstallArtificialBodyPart
    {

        public override AcceptanceReport AvailableReport(Thing thing, BodyPartRecord part = null)
        {
            Pawn pawn;
            if ((pawn = thing as Pawn) == null)
            {
                return false;
            }
            //Log.Message(pawn.RaceProps.baseBodySize);
            if (pawn.RaceProps.baseBodySize < AlphaImplants_Settings.archotechBodyLimit)
            {
                return false;
            }
            return base.AvailableReport(thing, part);
        }

        



    }


}

