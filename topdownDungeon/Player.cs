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

        int playerSpeed = 7;

        public Player(int position_x, int position_y)
        {
            x = position_x;
            y = position_y;
            height = 64;
            width = height;

            playerRec = new Rectangle(x,y,width,height);
        }

        public void drawPlayer(Graphics g)
        {
            playerRec.Location = new Point(x, y);

            g.FillRectangle(Brushes.Black, playerRec);
        }

        public void movePlayer(bool playerLeft, bool playerRight, bool playerUp, bool playerDown, Size Canvas)
        {
            if (playerLeft)
            {
                x -= playerSpeed;

                while (playerOutOfBounds(x, y, playerRec, Canvas))
                {
                    x++;
                }
            }

            if (playerRight)
            {
                x += playerSpeed;

                while (playerOutOfBounds(x, y, playerRec, Canvas))
                {
                    x--;
                }
            }

            if (playerUp)
            {
                y -= playerSpeed;

                while (playerOutOfBounds(x, y, playerRec, Canvas))
                {
                    y++;
                }
            }

            if (playerDown)
            {
                y += playerSpeed;

                while(playerOutOfBounds(x, y, playerRec, Canvas))
                {
                    y--;
                }
            }
        }


        private bool playerOutOfBounds(int player_x, int player_y, Rectangle Player, Size Canvas)
        {
            if (player_x < 0 || player_x > (Canvas.Width - Player.Width))
            {
                return true;
            }
            else if (player_y < 0 || player_y > (Canvas.Height - Player.Height))
            {
                return true;
            }
            return false;
        }
    }
}
