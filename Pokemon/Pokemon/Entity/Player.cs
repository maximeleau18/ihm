using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class Player
    {
        public enum Orientation
        {
            Up_0,
            Up_1,
            Up_2,
            Up_3,

            Down_0,
            Down_1,
            Down_2,
            Down_3,

            Right_0,
            Right_1,
            Right_2,
            Right_3,

            Left_0,
            Left_1,
            Left_2,
            Left_3,
        }

        private String name;
        private String sexe;
        private String urlCharacter;
        private Orientation currentOrientation;
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

        private List<String> orientationPaths;

        public Player()
        {
            orientationPaths = new List<String>();

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_04.png");

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_04.png");

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_04.png");
                                                                                                      
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_04.png");
        }

        public Player(String _name)
        {
            this.Name = _name;

            orientationPaths = new List<string>();

            //orientationPaths[(int)Orientation.Up_0] = "ms-appx:///Images/Sprites/Sprite_Up_01.png";
            //orientationPaths[(int)Orientation.Up_1] = "ms-appx:///Images/Sprites/Sprite_Up_02.png";
            //orientationPaths[(int)Orientation.Up_2] = "ms-appx:///Images/Sprites/Sprite_Up_03.png";
            //orientationPaths[(int)Orientation.Up_3] = "ms-appx:///Images/Sprites/Sprite_Up_04.png";

            //orientationPaths[(int)Orientation.Down_0] = "ms-appx:///Images/Sprites/Sprite_Down_01.png";
            //orientationPaths[(int)Orientation.Down_1] = "ms-appx:///Images/Sprites/Sprite_Down_02.png";
            //orientationPaths[(int)Orientation.Down_2] = "ms-appx:///Images/Sprites/Sprite_Down_03.png";
            //orientationPaths[(int)Orientation.Down_3] = "ms-appx:///Images/Sprites/Sprite_Down_04.png";

            //orientationPaths[(int)Orientation.Left_0] = "ms-appx:///Images/Sprites/Sprite_Left_01.png";
            //orientationPaths[(int)Orientation.Left_1] = "ms-appx:///Images/Sprites/Sprite_Left_02.png";
            //orientationPaths[(int)Orientation.Left_2] = "ms-appx:///Images/Sprites/Sprite_Left_03.png";
            //orientationPaths[(int)Orientation.Left_3] = "ms-appx:///Images/Sprites/Sprite_Left_04.png";

            //orientationPaths[(int)Orientation.Right_0] = "ms-appx:///Images/Sprites/Sprite_Right_01.png";
            //orientationPaths[(int)Orientation.Right_1] = "ms-appx:///Images/Sprites/Sprite_Right_02.png";
            //orientationPaths[(int)Orientation.Right_2] = "ms-appx:///Images/Sprites/Sprite_Right_03.png";
            //orientationPaths[(int)Orientation.Right_3] = "ms-appx:///Images/Sprites/Sprite_Right_04.png";

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Up_04.png");

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Down_04.png");

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Left_04.png");

            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_01.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_02.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_03.png");
            orientationPaths.Add("ms-appx:///Images/Sprites/Sprite_Right_04.png");

            this.CurrentOrientation = Orientation.Down_0;
        }

        public String GetOrientationImagePath()
        {
            return orientationPaths[(int)currentOrientation];
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
        
        internal Orientation CurrentOrientation
        {
            get
            {
                return currentOrientation;
            }

            set
            {
                currentOrientation = value;
            }
        }
    }
}
