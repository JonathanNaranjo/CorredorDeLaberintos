using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Textures;


namespace Game.Entities
{
    class Score : Entity
    {
        int coins;
        int diamonds;

        public void IncrementCoin()
        {
            coins++;
        }

        public void IncrementDiamond()
        {
            diamonds++;
        }
    }
}
