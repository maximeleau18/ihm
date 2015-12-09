using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKMTEMP.Entity
{
    class Player
    {
        private String name;
        private int money;

        private int positionX;
        private int positionY;

        private List<Pokemon> pokedex;
        private List<Pokemon> team;
        private List<Pokemon> pc;

        private List<MedicObject> medicPocket;
        private List<StatusObject> statusPocket;
        private List<BattleObject> battlePocket;
        private List<BallObject> ballPocket;

        public Player(String _nom)
        {

        }

        public void UtiliserObjet(PokemonObject _objet)
        {

        }

        

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Money
        {
            get
            {
                return money;
            }

            set
            {
                money = value;
            }
        }

        internal List<Pokemon> Team
        {
            get
            {
                return team;
            }

            set
            {
                team = value;
            }
        }

        internal List<Pokemon> Pc
        {
            get
            {
                return pc;
            }

            set
            {
                pc = value;
            }
        }

       
       
    }
}
