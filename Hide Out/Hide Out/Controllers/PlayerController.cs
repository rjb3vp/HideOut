using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hide_Out.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Hide_Out.Controllers
{
    class PlayerController
    {
        Player thePlayer;

        public PlayerController(Player player)
        {
            this.thePlayer = player;
        }

        public void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.moveLeft();
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.moveRight();

            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                this.moveUp();

            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                this.moveDown();
            }
        }

        public void moveRight()
        {
            thePlayer.Position += new Vector2(thePlayer.CurrentSpeed, 0);
        }

        public void moveLeft()
        {
            thePlayer.Position += new Vector2(-1*thePlayer.CurrentSpeed, 0);
        }

        public void moveUp()
        {
            thePlayer.Position += new Vector2(0, thePlayer.CurrentSpeed);
        }

        public void moveDown()
        {
            thePlayer.Position += new Vector2(0, -1*thePlayer.CurrentSpeed);
        }

        public void pickupItem(Item item)
        {
            if (thePlayer.Items.Count < 3)
            {
                thePlayer.Items.Add(item);
                item.Position = new Vector2(-1, -1);
                //todo: set item to not be drawn
            }
        }

        public void dropItem(Item item)
        {
            thePlayer.Items.Remove(item);
        }

        public void useItem(int index)
        {
            if (index >= 0 && index < thePlayer.Items.Count)
            {
                //todo: call itemController's add item
            }
        }
    }
}
