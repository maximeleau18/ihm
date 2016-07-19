using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Position : EntityBase
    {
        private int id;
        private int x;
        private int y;
        private Zone zone;

        public Position() { }

        public Position(int id, int x, int y, Zone zone)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.zone = zone;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public Zone Zone
        {
            get
            {
                return zone;
            }

            set
            {
                zone = value;
            }
        }
    }
}
