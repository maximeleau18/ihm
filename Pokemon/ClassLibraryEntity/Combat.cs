using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntity
{
    public class Combat : EntityBase
    {
        private DateTime lanceLe;
        private int duree;
        private bool pokemon1Vainqueur;
        private bool pokemon2Vainqueur;
        private bool dresseur1Vainqueur;
        private bool dresseur2Vainqueur;
        private PersonnageNonJoueur adversaire1;
        private PersonnageNonJoueur adversaire2;
        private Pokemon pokemonAdverse1;
        private Pokemon pokemonAdverse2;

        public Combat() { }

        public Combat(DateTime lanceLe, int duree, bool pokemon1Vainqueur, bool pokemon2Vainqueur, bool dresseur1Vainqueur, bool dresseur2Vainqueur, PersonnageNonJoueur adversaire1, PersonnageNonJoueur adversaire2, Pokemon pokemonAdverse1, Pokemon pokemonAdverse2)
        {
            this.lanceLe = lanceLe;
            this.duree = duree;
            this.pokemon1Vainqueur = pokemon1Vainqueur;
            this.pokemon2Vainqueur = pokemon2Vainqueur;
            this.dresseur1Vainqueur = dresseur1Vainqueur;
            this.dresseur2Vainqueur = dresseur2Vainqueur;
            this.adversaire1 = adversaire1;
            this.adversaire2 = adversaire2;
            this.pokemonAdverse1 = pokemonAdverse1;
            this.pokemonAdverse2 = pokemonAdverse2;
        }

        public DateTime LanceLe
        {
            get
            {
                return lanceLe;
            }

            set
            {
                lanceLe = value;
            }
        }

        public int Duree
        {
            get
            {
                return duree;
            }

            set
            {
                duree = value;
            }
        }

        public bool Pokemon1Vainqueur
        {
            get
            {
                return pokemon1Vainqueur;
            }

            set
            {
                pokemon1Vainqueur = value;
            }
        }

        public bool Pokemon2Vainqueur
        {
            get
            {
                return pokemon2Vainqueur;
            }

            set
            {
                pokemon2Vainqueur = value;
            }
        }

        public bool Dresseur1Vainqueur
        {
            get
            {
                return dresseur1Vainqueur;
            }

            set
            {
                dresseur1Vainqueur = value;
            }
        }

        public bool Dresseur2Vainqueur
        {
            get
            {
                return dresseur2Vainqueur;
            }

            set
            {
                dresseur2Vainqueur = value;
            }
        }

        public PersonnageNonJoueur Adversaire1
        {
            get
            {
                return adversaire1;
            }

            set
            {
                adversaire1 = value;
            }
        }

        public PersonnageNonJoueur Adversaire2
        {
            get
            {
                return adversaire2;
            }

            set
            {
                adversaire2 = value;
            }
        }

        public Pokemon PokemonAdverse1
        {
            get
            {
                return pokemonAdverse1;
            }

            set
            {
                pokemonAdverse1 = value;
            }
        }

        public Pokemon PokemonAdverse2
        {
            get
            {
                return pokemonAdverse2;
            }

            set
            {
                pokemonAdverse2 = value;
            }
        }
    }
}
