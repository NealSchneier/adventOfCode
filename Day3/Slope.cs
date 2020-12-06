
using System.Collections.Generic;

namespace Day3
{
    public class Slope
    {
        public int Right;
        public int Down;
    }
    public class Terrain
    {
        public List<bool>[] Land;
    }
    public class Position
    {
        public int x = 0;
        public int y = 0;
        public long TreeCount = 0;
    }
}
