using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Gamer
    {
        private static int anonimousGamers;
        public string NickName { get; set; }
        public List<Map> Maps { get; set; }
        static Gamer() => anonimousGamers = 0;
        public Gamer(string NickName = " ")
        {
            Maps = new List<Map>();
            if (NickName != " ")
            {
                NickName = NickName;
            }
            else NickName = "Anonimous" + ++anonimousGamers;
        }
        public int AmmoutOfMaps() => Maps.Count;
        public Map GiveMap(int map) => Maps[map];
        public void UploadMap(Map map) => Maps.Add(map);
        public void PickUpMap(Map map) => Maps.RemoveAt(Maps.IndexOf(map));

        internal void AddMap(Map map)
        {
            throw new NotImplementedException();
        }

        internal object GetMap(int n)
        {
            throw new NotImplementedException();
        }
    }
}
