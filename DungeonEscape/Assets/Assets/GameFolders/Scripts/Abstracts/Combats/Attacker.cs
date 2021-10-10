using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class Attacker : MonoBehaviour, IAttacker
    {
        [SerializeField] int damage = 1;

        public int Damage => damage;

        public virtual void Attack(ITakeHit takeHit)
        {
            takeHit.TakeHit(this);
        }
    }
}