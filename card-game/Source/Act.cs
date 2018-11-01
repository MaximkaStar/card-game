using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Source
{
    public delegate void WinGamer(string NickName);
    public class Act
    {
        public event WinGamer WinGamer;
        public const int MIN_AM_OF_GAMERS = 2;
        public const int MAPS_SRS = 0;
        public const int NICKNAME_SRS = 1;
        public const int MESGE_SRS = 2;
        public const int TXT_SRS = 3;

        Map max = new Map(StyleOfMaps.Nothing, ColorOfMaps.Nothing);
        private List<Gamer> Gamers;
        private List<Map> Desk; 
        private int actualGamerStep;
        public Act(int ammoutOfGamers = MIN_AM_OF_GAMERS)
        {
            if(ammoutOfGamers < MIN_AM_OF_GAMERS)
            {
                throw new ArgumentException("Sorry, you have not enough gamers.");
            }
            if(ammoutOfGamers % ammoutOfGamers !=0)
            {
                throw new ArgumentException("The number of players must be a multiple of 53.");
            }
            Gamers = new List<Gamer>();
            for(int j =0; j < ammoutOfGamers; j++)
            {
                Gamers.Add(new Gamer());
            }
        }
        public Act(int ammoutOfGamers = MIN_AM_OF_GAMERS, params string[] NickNames)
        {
            if (ammoutOfGamers < MIN_AM_OF_GAMERS)
            {
                throw new ArgumentException("Gamers could be biggest than 1.");
            }
            if (ammoutOfGamers % ammoutOfGamers != 0)
            {
                throw new ArgumentException("The number of players must be a multiple of 53");
            }
            if (NickNames.Length < ammoutOfGamers)
            {
                throw new ArgumentException("Ammount of nicknames should be greater than or equal to the number of players");
            }
            Gamers = new List<Gamer>();
            for(int j = 0; j < ammoutOfGamers; j++)
            {
                Gamers.Add(new Gamer(NickNames[j]));
            }
        }
        public void StartAct()
        {
            UploadDesk();
            actualGamerStep = 0;
            Desk = new List<Map>();
        }
        public void Step(Map map)
        {
            for (int j = 0; j < Gamers.Count; j++)
            {
                if (Gamers.[j].Maps.Count >= Map.AMMOUT_OF_COLOR_OF_CARDS * Map.AMMOUT_OF_STYLE_OF_CARDS)
                {
                    StartAct();
                    WinGamer(Gamers[actualGamerStep].NickName);
                }
                if (actualGamerStep >= Gamers.Count - 1)
                {
                    for(int i = 0; i < Gamers.Count; i++)
                    {
                        if(Gamers[i].Maps.Contains(max))
                        {
                            for (int m = 0; m < Desk.Count; m++) 
                            {
                                Gamers[m].AddMap(Desk[m]);
                                Desk.Clear();
                            }
                        }
                    }
                    actualGamerStep = 0;
                }
                else
                {
                    if((int)map.Type > (int)max.Type)
                    {
                        max = map;
                    }
                    Desk.Add(map);
                    Gamers[actualGamerStep].Maps.PickUpMap(map);
                    actualGamerStep++;
                }

            }
        }
        public string[] GiveCamersMaps()
        {
            const int LTR_AMT = 3;
            string[] letter = new string[LTR_AMT];
            letter[TXT_SRS] = "Your maps is: ";
            StringBuilder builder = new StringBuilder();
            for (int n = 0; n < Gamers[actualGamerStep].AmmoutOfMaps(); n++)
            {
                builder.AppendFormat("{0}", Gamers[actualGamerStep].GetMap(n));
            }
            letter[MAPS_SRS] = builder.ToString();
            letter[NICKNAME_SRS] = Gamers[actualGamerStep].NickName;
            return letter;
        }
        public Gamer ActualGamer()
        {
            return Gamers[actualGamerStep];
        }
        public void Reload()
        {
            int ammoutOfGamers = Gamers.Count;
            string[] NickNames = new string[ammoutOfGamers];
            for(int n = 0; n < ammoutOfGamers; n++)
            {
                NickNames[n] = Gamers[n].NickName;
            }
            Gamers.Clear();
            Gamers = new List<Gamer>();
            for(int m = 0; m < ammoutOfGamers; m++)
            {
                Gamers.Add(new Gamer(NickNames[m]));
            }
            StartAct();
        }
        public void UploadDesk()
        {
            int numOfMapsForOneGamer = Map.AMMOUT_OF_COLOR_OF_CARDS * Map.AMMOUT_OF_STYLE_OF_CARDS / Gamers.Count;
            List<Map> allMaps = new List<Map>();
            for (int k = 0; k < Map.AMMOUT_OF_COLOR_OF_CARDS; k++) 
            {
                for (int u = 13; u < Map.AMMOUT_OF_STYLE_OF_CARDS + 13; u++)
                {
                    allMaps.Add(new Map((StyleOfMaps)u, (ColorOfMaps)u));
                }

            }
            Random chance = new Random();
            for( int o = 0; o < Gamers.Count; o++)
            {
                for(int l = 0; l < numOfMapsForOneGamer; l++)
                {
                    Map kms = allMaps[chance.Next(0, allMaps.Count)];
                    Gamers[l].AddMap(kms);
                    allMaps.Remove(kms);
                }
            }
        }
    }
}
