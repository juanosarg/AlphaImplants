
using RimWorld;
using Verse;
namespace AlphaImplants
{
    public class PawnRenderNodeWorker_OverlayWounds : PawnRenderNodeWorker_Overlay
    {
        protected override PawnOverlayDrawer OverlayDrawer(Pawn pawn)
        {
            return new PawnBoomNodulesDrawer(pawn);
        }

        public override bool CanDrawNow(PawnRenderNode node, PawnDrawParms parms)
        {
            if (base.CanDrawNow(node, parms))
            {
                return true;
            }
            return false;
        }
    }
}
