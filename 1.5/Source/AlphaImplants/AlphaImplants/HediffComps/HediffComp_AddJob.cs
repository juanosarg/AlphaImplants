
using Verse;
using RimWorld;

namespace AlphaImplants
{
    class HediffComp_AddJob : HediffComp
    {

     
        public HediffCompProperties_AddJob Props
        {
            get
            {
                return (HediffCompProperties_AddJob)this.props;
            }
        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (this.parent.pawn.IsHashIntervalTick(2000))
            {
                StaticCollectionsClass.AddPawnAndJobgiver(this.parent.pawn, Props.jobToAdd);
            }
        }

        public override void CompPostPostAdd(DamageInfo? dinfo)
        {

            StaticCollectionsClass.AddPawnAndJobgiver(this.parent.pawn, Props.jobToAdd);

        }

        public override void CompPostPostRemoved()
        {
            StaticCollectionsClass.RemovePawnAndJobgiver(this.parent.pawn, Props.jobToAdd);

        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            StaticCollectionsClass.RemovePawnOutright(this.parent.pawn);

        }

        public override void Notify_PawnKilled()
        {
            StaticCollectionsClass.RemovePawnOutright(this.parent.pawn);

        }
    }
}
