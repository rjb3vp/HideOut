using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_Out.Entities
{
    enum ObstacleType { Bush, Tree, Fountain, Pond };
    class Obstacle : Entity
    {
        Boolean CanOverlapWith { get; set; }
        Boolean CanSeeThrough { get; set; }
        ObstacleType Tag { get; set; }
    }
}
