using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneHourChallengeFlappySpace
{
    internal class WallHandaler
    {
        (int y, int length)[] walls = new (int x, int length)[6];
        int[] wallsPrevY = new int[6];
        Random rnd = new Random();
        int gap = 15;
        public char wallSym = 'X';
        public void NewGenerateAllWalls()
        {
            int steps = Console.WindowHeight/walls.Length;
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].y = i*steps;
                walls[i].length = rnd.Next(gap,Console.WindowWidth-gap);
            }
        }
        public void WriteAllWalls()
        {
            foreach (var wall in walls)
            {
                Console.SetCursorPosition(0,wall.y);

                for (int i = 0;i < wall.length; i++)
                    Console.Write(wallSym);
                for (int i = 0; i < gap; i++)
                    Console.Write(' ');
                for (int i = 0; i < Console.WindowWidth-gap-wall.length; i++)
                    Console.Write(wallSym);
            }

            for (int i = 0; i < walls.Length; i++)
            {
                if (wallsPrevY[i] != walls[i].y)
                {
                    Console.SetCursorPosition(0, wallsPrevY[i]);
                    for (int j = 0; j < Console.WindowWidth; j++)
                        Console.Write(' ');
                    //Console.WriteLine("=============\nwdawwd\nwadwad=");
                    wallsPrevY[i] = walls[i].y;
                }
            }
        }
        public void Uppdate()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                if (walls[i].y == Console.WindowHeight - 1)
                    walls[i].y = 0;
                else
                    walls[i].y++;
            }
        }
        public bool CheckColision(ref Player player)
        {
            foreach(var wall in walls)
            {
                if (wall.y == player.pos.y && (player.pos.x <= wall.length || player.pos.x > wall.length+gap))
                    return true;
            }
            return false;
        }
    }
}
