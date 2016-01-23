using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class Statistics
    {
        private int life;
        private int attack;
        private int armor;
        private int speed;
        
        public Statistics()
        {
            life = 0;
            attack = 0;
            armor = 0;
            speed = 0;
        }

        public Statistics(int _life, int _attack, int _armor, int _speed)
        {
            this.life = _life;
            this.attack = _attack;
            this.armor = _armor;
            this.speed = _speed;
        }

        public Statistics(Statistics _origin)
        {
            this.life = _origin.life;
            this.attack = _origin.attack;
            this.armor = _origin.armor;
            this.speed = _origin.speed;
        }


        public int Life
        {
            get
            {
                return life;
            }

            set
            {
                life = value;
            }
        }

        public int Attack
        {
            get
            {
                return attack;
            }

            set
            {
                attack = value;
            }
        }

        public int Armor
        {
            get
            {
                return armor;
            }

            set
            {
                armor = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }
    }
}
