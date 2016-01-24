using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class MedicObject : PokemonObject, ObjectAsTarget
    {
        StatusObject status;

        public MedicObject(String name, String urlPicture, StatusObject statusObj) : base(name, urlPicture)
        {
            status = statusObj;
        }


        public MedicObject(String name, String urlPicture) : base(name, urlPicture)
        {
        }
    }
}
