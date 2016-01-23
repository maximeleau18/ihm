using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class Player
    {
        private String name;
        private String sexe;
        private String urlCharacter;
        private int money;
        
        private List<Pokemon> pokedex;
        private List<Pokemon> team;
        private List<Pokemon> pc;

        private List<MedicObject> medicPocket;
        private List<StatusObject> statusPocket;
        private List<BattleObject> battlePocket;
        private List<BallObject> ballPocket;

        private int posX;
        private int posY;

        public Player()
        {

        }

        public Player(String _name)
        {
            this.Name = _name;
        }

        public void UtiliserObjet(ObjectAsTarget _objet, Pokemon playerPkm)
        {

        }

        public void UtiliserObjet(BallObject _objet, Pokemon opponentPokemon)
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

        public string Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
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

        public string UrlCharacter
        {
            get
            {
                return urlCharacter;
            }

            set
            {
                urlCharacter = value;
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

        public int PosX
        {
            get
            {
                return posX;
            }

            set
            {
                posX = value;
            }
        }

        public int PosY
        {
            get
            {
                return posY;
            }

            set
            {
                posY = value;
            }
        }
    }
}
