using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_Out.Entities
{
    enum ItemType { WaterBottle, CandyBar }; 
    class Item : Entity
    {
        ItemType Tag { get; set; }
    }
}
