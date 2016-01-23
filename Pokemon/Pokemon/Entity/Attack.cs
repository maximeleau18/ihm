﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Entity
{
    class Attack
    {
        private String name;

        private bool asDamageEffect;
        private int damage;

        private bool asHealEffect;
        private int heal;

        private TypePokemon type;

        private bool asStatusDealEffect;
        private StatusPokemon statusDeal;

        public Attack(String name, TypePokemon type)
        {
            this.name = name;
            this.type = type;
        }

        public void AddDamage(int damage)
        {
            this.damage = damage;
            this.asDamageEffect = true;
        }

        public void AddHeal(int heal)
        {
            this.heal = heal;
            this.asHealEffect = true;
        }

        public void AddStatusDeal(StatusPokemon status)
        {
            this.statusDeal = status;
            this.asStatusDealEffect = true;
        }
    }
}
