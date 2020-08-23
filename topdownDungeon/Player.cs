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

        public void movePlayer(bool playerLeft, bool playerRight, bool playerUp, bool playerDown)
        {
            if (playerLeft)
            {
                x -= playerSpeed;
            }

            if (playerRight)
            {
                x += playerSpeed;
            }

            if (playerUp)
            {
                y -= playerSpeed;
            }

            if (playerDown)
            {
                y += playerSpeed;
            }
        }
    }
}
