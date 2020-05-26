using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class TPlayer
    {
        public List<THero> Heroes = new List<THero>();
        public Color ColorId;
        public List<int> Resources = new List<int>();
        public int HeroesCount = 3;

        public TPlayer(TGame Game)
        {
            for(int i = 0; i < HeroesCount; i++)
            {
                var rnd = TGame.Random;
                var hero = new THero();
                hero.Player = this;
                hero.CurrentCell = Game.FreeCells[rnd.Next(Game.FreeCells.Count)];
                hero.Name = i.ToString();
                Heroes.Add(hero);
            }
        }
    }
}
