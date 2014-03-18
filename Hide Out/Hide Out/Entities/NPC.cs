using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hide_Out.Primatives;

namespace Hide_Out.Entities
{
    enum NPCType { Police, Bird, Squirrel };
    class NPC : Entity
    {
        Vision Vision { get; set; }
        int Speed { get; set; }
        NPCType Tag { get; set; }
    }
}
