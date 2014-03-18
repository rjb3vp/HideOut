using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Hide_Out.Entities
{
    abstract class Entity
    {
        Vector2 Position { get; set; }
        Texture2D Sprite { get; set; }
        public Entity()
        {
        }
    }
}
