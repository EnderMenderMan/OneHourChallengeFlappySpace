using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneHourChallengeFlappySpace
{
    internal class Game
    {

        WallHandaler wallHand = new WallHandaler();
        Player player = new Player();

        public Game()
        {
        }
        public void Run()
        {
            wallHand.NewGenerateAllWalls();

            uint loopCycle = 0;
            while (true)
            {
                player.Uppdate();
                if (wallHand.CheckColision(ref player))
                {
                    break;
                }

                if (loopCycle == 0)
                    wallHand.Uppdate();
                Render();
                //Thread.Sleep(30);
                if (loopCycle > 100)
                    loopCycle = 0;
                else
                    loopCycle++;
            }
            Console.Clear();
            Console.WriteLine("\nGAME OVER!!!");
        }
        void Render()
        {
            wallHand.WriteAllWalls();
            player.Write();
        }
    }
}
