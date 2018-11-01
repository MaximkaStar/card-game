using Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CardGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int ammoutOfPlayers = 2;
            Act act = new Act(ammoutOfPlayers);
            WinGamer winGamer = (NickName) => WriteLine("WINNER IS: " + NickName);
            act.WinGamer += winGamer;
            act.StartAct();
            while(true)
            {
                var letter = act.GiveCamersMaps();
                WriteLine("NickName: {0}", letter[Act.NICKNAME_SRS]);
                WriteLine(letter[Act.MAPS_SRS]);
                WriteLine(letter[Act.TXT_SRS]);

                int num;
                WriteLine("Please, enter the number of map:");
                while (!int.TryParse(ReadLine(), out num))
                {
                    Clear();
                    Write("Please, enter the number of map:");
                }
                act.Step(act.ActualGamer().Maps[num]);
                Clear();
            }
        }
    }
}
