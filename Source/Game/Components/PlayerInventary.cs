using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Components
{
    class PlayerInventary : Component
    {
        private int diamonds;
        private int coins;

        public int Diamonds { get => diamonds; set => diamonds = value; }
        public int Coins { get => coins; set => coins = value; }

        public void ResetInventary()
        {
            Diamonds = 0;
            Coins = 0;
        }
    }
}
