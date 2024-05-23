using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneHourChallengeFlappySpace
{
    internal class Player
    {
        public (int x, int y) pos = (Console.WindowWidth/2, Console.WindowHeight - 1);
        public (int x, int y) posPrev = (0, 0);
        public char playerSym = 'A';
        public void Write()
        {
            if (posPrev != pos)
            {
                Console.SetCursorPosition(posPrev.x, posPrev.y);
                Console.Write(' ');
                posPrev = pos;
            }

            Console.SetCursorPosition(pos.x,pos.y);
            Console.Write(playerSym);
        }
        public void Uppdate()
        {
            if (!Console.KeyAvailable)
                return;

            switch (Console.ReadKey(true).KeyChar)
            {
                case 'a':
                    if (pos.x > 0)
                        pos.x--;
                    break;
                case 'd':
                    if (pos.x < Console.WindowWidth-1)
                        pos.x++;
                    break;
                case 'w':
                    if (pos.y > 0)
                        pos.y--;
                    break;
                case 's':
                    if (pos.y < Console.WindowHeight-1)
                        pos.y++;
                    break;
            }
        }
    }
}
