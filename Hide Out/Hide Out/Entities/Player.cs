using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_Out.Entities
{
    class Player : Entity
    {
        int CurrentSpeed { get; set; }
        int MaxSpeed { get; set; }
        int CurrentThirst { get; set; }
        int MaxThirst { get; set; }
        int CurrentHunger { get; set; }
        int MaxHunger { get; set; }
        List<Item> Items { get; set; }

    }
}
