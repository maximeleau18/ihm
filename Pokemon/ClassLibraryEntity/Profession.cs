using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Profession : EntityBase
    {
        private int id;
        private String nom;

        public Profession() { }

        public Profession(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        [PrimaryKey, AutoIncrement]
        [Column("id")]
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

        [Column("nom")]
        public String Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
