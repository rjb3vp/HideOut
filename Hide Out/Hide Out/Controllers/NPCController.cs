using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hide_Out.Entities;

namespace Hide_Out.Controllers
{
    class NPCController
    {
        public void UpdateNPCs(List<NPC> npcs)
        {
            foreach (NPC npc in npcs)
            {
                UpdateNPC(npc);
            }
        }

        public void UpdateNPC(NPC npc)
        {
            switch (npc.tag)
            {
                case NPCType.Police:
                    npc.Move(npc.vision.viewDirection);
                    npc.Rotate(.05);
                    break;
            }
        }
    }
}
