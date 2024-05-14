
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaImplants
{
    public class HediffComp_VerbGiverScaling : HediffComp, IVerbOwner
    {
        public VerbTracker verbTracker;

        public HediffCompProperties_VerbGiverScaling Props => (HediffCompProperties_VerbGiverScaling)props;

        public VerbTracker VerbTracker => verbTracker;

        public List<VerbProperties> VerbProperties => Props.verbs;

        public List<Tool> cachedTools;


        public List<Tool> Tools {

            get
            {
                Log.Message("working");
                if(cachedTools == null)
                {
                    foreach (Tool tool in Props.tools)
                    {
                        Tool tool2 = tool;
                        tool2.power = tool.power * 1000;
                        tool2.cooldownTime = tool.cooldownTime * 0.1f;
                        cachedTools.Add(tool2);
                    }

                }
                return cachedTools;

                
            }
            

        }

        

        Thing IVerbOwner.ConstantCaster => base.Pawn;

        ImplementOwnerTypeDef IVerbOwner.ImplementOwnerTypeDef => Props.ownerTypeOverride ?? ImplementOwnerTypeDefOf.Hediff;

        public HediffComp_VerbGiverScaling()
        {
            verbTracker = new VerbTracker(this);
        }

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Deep.Look(ref verbTracker, "verbTracker", this);
            if (Scribe.mode == LoadSaveMode.PostLoadInit && verbTracker == null)
            {
                verbTracker = new VerbTracker(this);
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            verbTracker.VerbsTick();
        }

        string IVerbOwner.UniqueVerbOwnerID()
        {
            return parent.GetUniqueLoadID() + "_" + parent.comps.IndexOf(this);
        }

        bool IVerbOwner.VerbsStillUsableBy(Pawn p)
        {
            return p.health.hediffSet.hediffs.Contains(parent);
        }
    }
}