using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hide_Out.Entities
{
    class Player : Entity
    {
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentThirst { get; set; }
        public int MaxThirst { get; set; }
        public int CurrentHunger { get; set; }
        public int MaxHunger { get; set; }
        public List<Item> Items { get; set; }

        public Player(int x, int y, Texture2D sprite, int currentSpeed, int maxSpeed, int currentThirst, int maxThirst, int currentHunger, int maxHunger)
        {
            this.CurrentSpeed = currentSpeed;
            this.MaxSpeed = MaxSpeed;
            this.CurrentThirst = currentThirst;
            this.MaxThirst = maxThirst;
            this.CurrentHunger = currentHunger;
            this.MaxHunger = maxHunger;
            this.Items = new List<Item>();
            this.Position = new Vector2(x, y);
            this.Sprite = sprite;
        }

        public Player(int maxSpeed, int maxThirst, int maxHunger)
            : this(0, 0, null, maxSpeed, maxSpeed, maxThirst, maxThirst, maxHunger, maxHunger)
        {

        }

        public Player(int x, int y, Texture2D sprite) 
            : this(x, y, sprite, 10, 10, 10, 10, 10, 10)
        {
            
        }

        public Player() 
            : this(0, 0, null)
        {

        }

        public void moveRight()
        {
            this.Position += new Vector2(this.CurrentSpeed, 0);
        }

        public void moveLeft()
        {
            this.Position += new Vector2(-1 * this.CurrentSpeed, 0);
        }

        public void moveUp()
        {
            this.Position += new Vector2(0, this.CurrentSpeed);
        }

        public void moveDown()
        {
            this.Position += new Vector2(0, -1 * this.CurrentSpeed);
        }

        public override string ToString()
        {
            return base.ToString() +
                "Speed: " + this.CurrentSpeed + " / " + this.MaxSpeed + "\n" +
                "Thirst: " + this.CurrentThirst + " / " + this.MaxThirst + "\n" +
                "Hunger: " + this.CurrentHunger + " / " + this.MaxHunger + "\n" +
                "Items: " + this.Items;
        }
    }
}
