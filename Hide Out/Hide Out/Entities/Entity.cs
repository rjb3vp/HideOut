﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Hide_Out.Entities
{
    abstract class Entity
    {
        public Vector2 Position { get; set; }
        public Rectangle Rectangle { get; set; } //Needed for intersection/collision checks
        public Texture2D Sprite { get; set; }
        public Entity()
        {
        }
    }
}
