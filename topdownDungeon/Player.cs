using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace topdownDungeon
{
    class Player
    {
        int x, y, width, height;

        Rectangle playerRec;

        Image playerImage;

        int playerSpeed = 8;

        bool facingLeft = true;

        public Player(int position_x, int position_y)
        {
            x = position_x;
            y = position_y;
            height = 64;
            width = height;

            playerImage = Properties.Resources.teen_wizard_base;

            playerRec = new Rectangle(x,y,width,height);
        }

        public void drawPlayer(Graphics g, bool hitbox_visible)
        {
            updateSpriteDirection();

            g.DrawImage(playerImage, playerRec);
            if(hitbox_visible)
            {
                g.DrawRectangle(new Pen(Color.Yellow, 1.0f), hitbox());
            }
        }

        private void updateSpriteDirection()
        {
            if(facingLeft)
            {
                playerRec.Width *= -1;
            }
            else
            {
                playerRec.Width = width;
            }
        }

        public void movePlayer(bool playerLeft, bool playerRight, bool playerUp, bool playerDown, Size Canvas)
        {
            if (playerLeft)
            {
                x -= playerSpeed;

                playerRec.Location = new Point(x, y);

                while (playerOutOfBounds(x, y, hitbox(), Canvas))
                {
                    x++;
                    playerRec.Location = new Point(x, y);
                }

                facingLeft = true;
            }

            if (playerRight)
            {
                x += playerSpeed;

                playerRec.Location = new Point(x, y);

                while (playerOutOfBounds(x, y, hitbox(), Canvas))
                {
                    x--;
                    playerRec.Location = new Point(x, y);
                }

                facingLeft = false;
            }

            if (playerUp)
            {
                y -= playerSpeed;

                playerRec.Location = new Point(x, y);

                while (playerOutOfBounds(x, y, hitbox(), Canvas))
                {
                    y++;
                    playerRec.Location = new Point(x, y);
                }
            }

            if (playerDown)
            {
                y += playerSpeed;

                playerRec.Location = new Point(x, y);

                while (playerOutOfBounds(x, y, hitbox(), Canvas))
                {
                    y--;
                    playerRec.Location = new Point(x, y);
                }
            }
        }

        public Rectangle hitbox()
        {
            Rectangle playerHitbox;
            int hitbox_x, hitbox_y, hitbox_width, hitbox_height;

            hitbox_height = playerRec.Height;
            hitbox_width = (playerRec.Width/3) + 8;

            hitbox_y = playerRec.Y;
            hitbox_x = playerRec.X + (playerRec.Width / 3) - 8;

            playerHitbox = new Rectangle(hitbox_x, hitbox_y, hitbox_width, hitbox_height);

            return playerHitbox;
        }

        private bool playerOutOfBounds(int player_x, int player_y, Rectangle Player, Size Canvas)
        {
            if (Player.X < 0 || Player.X > (Canvas.Width - Player.Width))
            {
                return true;
            }
            else if (Player.Y < 0 || Player.Y > (Canvas.Height - Player.Height))
            {
                return true;
            }
            return false;
        }
    }
}
