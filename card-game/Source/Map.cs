using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source
{
    public class Map
    {
        public const int AMMOUT_OF_STYLE_OF_CARDS = 13;
        public const int AMMOUT_OF_COLOR_OF_CARDS = 4;

        public StyleOfMaps Style { get; set; }
        public ColorOfMaps Color { get; set; }
        public int Type { get; internal set; }

        public Map(StyleOfMaps style, ColorOfMaps color)
        {
            Style = style;
            Color = color;
        }
        public override string ToString()
        {
            return Style.ToString() + " " + Color.ToString();
        }
    }
}
