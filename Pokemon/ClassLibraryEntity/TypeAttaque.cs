﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class TypeAttaque : EntityBase
    {
        private int id;
        private String nom;

        public TypeAttaque() { }

        public TypeAttaque(int id, String nom)
        {
            this.Id = id;
            this.Nom = nom;
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
    }
}
