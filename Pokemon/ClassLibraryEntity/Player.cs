using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Player : EntityBase
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
        
        public void UtiliserObjet(BallObject _objet, Pokemon opponentPokemon)
        {

        }

        public String Name
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

        public String Sexe
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

        public String UrlCharacter
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

        public List<Pokemon> Team
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

        public List<Pokemon> Pc
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
        
        public Orientation CurrentOrientation
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
