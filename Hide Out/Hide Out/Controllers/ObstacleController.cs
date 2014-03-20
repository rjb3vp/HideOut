using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hide_Out.Controllers
{
    class ObstacleController
    {
        double clicksSinceLastRandomize = 0;
        double refreshInterval = 10000;
        public ObstacleController()
        {

        }

        public void initialize() {
              clicksSinceLastRandomize = 0;
        }

        public void update(double elapsedMilliseconds)
        {
            clicksSinceLastRandomize += elapsedMilliseconds;

            if (clicksSinceLastRandomize > refreshInterval)
            {
                clicksSinceLastRandomize = 0;
                //loop through all trash cans, empty them
                //add something in a random trash can
            }

        }

    }
}
