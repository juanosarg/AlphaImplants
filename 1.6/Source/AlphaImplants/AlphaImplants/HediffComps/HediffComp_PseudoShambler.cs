
using Verse;
using RimWorld;

namespace AlphaImplants
{
    class HediffComp_PseudoShambler : HediffComp
    {


        public HediffCompProperties_PseudoShambler Props
        {
            get
            {
                return (HediffCompProperties_PseudoShambler)this.props;
            }
        }



        public override void CompPostPostAdd(DamageInfo? dinfo)
        {

            this.parent.pawn.Drawer.renderer.SetAnimation(Props.animation);

        }

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            if (!this.parent.pawn.Drawer.renderer.HasAnimation)
            {
                this.parent.pawn.Drawer.renderer.SetAnimation(Props.animation);
            }
            if (Rand.MTBEventOccurs(1f, 60f, 1f))
            {
                FleckMaker.ThrowShamblerParticles(this.parent.pawn);
            }
        }

        public override void CompPostPostRemoved()
        {
            this.parent.pawn.Drawer.renderer.SetAnimation(null);

        }

        public override void Notify_PawnDied(DamageInfo? dinfo, Hediff culprit = null)
        {
            this.parent.pawn.Drawer.renderer.SetAnimation(null);

        }

        public override void Notify_PawnKilled()
        {
            this.parent.pawn.Drawer.renderer.SetAnimation(null);

        }


    }
}
