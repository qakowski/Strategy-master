using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class TResource: TPiece
    {
        public enum TResourceType { rock, wood, iron, diamonds, sulfur, mercury}

        public TResourceType Type;
        public int Value;
    }
}
