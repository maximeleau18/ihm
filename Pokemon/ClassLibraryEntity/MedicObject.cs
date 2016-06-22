using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class MedicObject : PokemonObject
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
