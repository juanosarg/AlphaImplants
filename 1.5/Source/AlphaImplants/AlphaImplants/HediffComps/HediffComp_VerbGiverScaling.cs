
using System.Collections.Generic;
using RimWorld;
using Verse;
namespace AlphaImplants
{
    public class HediffComp_VerbGiverScaling : HediffComp_VerbGiver
    {
    

        public List<Tool> cachedTools;


       public new List<Tool> Tools {

            get
            {
               
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
    }
}