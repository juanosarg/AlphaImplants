
using RimWorld;
using UnityEngine;
using Verse;
namespace AlphaImplants
{
    public class PawnRenderNode_AnimalPartRotten : PawnRenderNode_AnimalPart
    {
        public PawnRenderNode_AnimalPartRotten(Pawn pawn, PawnRenderNodeProperties props, PawnRenderTree tree)
            : base(pawn, props, tree)
        {
        }

        public override GraphicMeshSet MeshSetFor(Pawn pawn)
        {
            Graphic graphic = GraphicFor(pawn);
            if (graphic != null)
            {
                return MeshPool.GetMeshSetForSize(graphic.drawSize.x, graphic.drawSize.y);
            }
            return null;
        }

        public override Graphic GraphicFor(Pawn pawn)
        {
            PawnKindLifeStage curKindLifeStage = pawn.ageTracker.CurKindLifeStage;
           
           
            Graphic graphic =  ((pawn.gender == Gender.Female && curKindLifeStage.femaleGraphicData != null) ? curKindLifeStage.femaleGraphicData.Graphic : curKindLifeStage.bodyGraphicData.Graphic);
            if (curKindLifeStage.corpseGraphicData != null)
            {
                graphic = ((pawn.gender == Gender.Female && curKindLifeStage.femaleCorpseGraphicData != null) ? curKindLifeStage.femaleCorpseGraphicData.Graphic.GetColoredVersion(curKindLifeStage.femaleCorpseGraphicData.Graphic.Shader, graphic.Color, graphic.ColorTwo) : curKindLifeStage.corpseGraphicData.Graphic.GetColoredVersion(curKindLifeStage.corpseGraphicData.Graphic.Shader, graphic.Color, graphic.ColorTwo));
            }

           

            switch (pawn.Drawer.renderer.CurRotDrawMode)
            {
                case RotDrawMode.Fresh:

                 
                    return graphic.GetColoredVersion(ShaderDatabase.Cutout, MutantUtility.GetShamblerColor(graphic.Color), MutantUtility.GetShamblerColor(graphic.ColorTwo));
                    
                   
                case RotDrawMode.Rotting:
                    return graphic.GetColoredVersion(ShaderDatabase.Cutout, PawnRenderUtility.GetRottenColor(graphic.Color), PawnRenderUtility.GetRottenColor(graphic.ColorTwo));
                case RotDrawMode.Dessicated:
                    if (curKindLifeStage.dessicatedBodyGraphicData != null)
                    {
                        Graphic graphic2;
                        if (pawn.RaceProps.FleshType != FleshTypeDefOf.Insectoid)
                        {
                            graphic2 = ((pawn.gender == Gender.Female && curKindLifeStage.femaleDessicatedBodyGraphicData != null) ? curKindLifeStage.femaleDessicatedBodyGraphicData.GraphicColoredFor(pawn) : curKindLifeStage.dessicatedBodyGraphicData.GraphicColoredFor(pawn));
                        }
                        else
                        {
                            Color dessicatedColorInsect = PawnRenderUtility.DessicatedColorInsect;
                            graphic2 = ((pawn.gender == Gender.Female && curKindLifeStage.femaleDessicatedBodyGraphicData != null) ? curKindLifeStage.femaleDessicatedBodyGraphicData.Graphic.GetColoredVersion(ShaderDatabase.Cutout, dessicatedColorInsect, dessicatedColorInsect) : curKindLifeStage.dessicatedBodyGraphicData.Graphic.GetColoredVersion(ShaderDatabase.Cutout, dessicatedColorInsect, dessicatedColorInsect));
                        }
                        if (pawn.IsMutant)
                        {
                            graphic2.ShadowGraphic = graphic.ShadowGraphic;
                        }
                       
                        return graphic2;
                    }
                    break;
            }
            return null;
        }
    }
}