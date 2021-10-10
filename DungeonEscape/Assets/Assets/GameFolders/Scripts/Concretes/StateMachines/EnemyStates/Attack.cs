using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject3.StateMachines.EnemyStates
{
    public class Attack : IState
    {
        IMyAnimation _animation;
        IAttacker _attacker;
        IFlip _flip;
        IHealth _playerHealth;
        System.Func<bool> _isPlayerRightSide;

        float _currentAttackTime;
        float _maxAttackTime;

        public Attack(IHealth playerHealth, IFlip flip, IMyAnimation animation, IAttacker attacker, float maxAttackTime, System.Func<bool>
            isPlayerRightSide)
        {
            _animation = animation;
            _attacker = attacker;
            _maxAttackTime = maxAttackTime;
            _playerHealth = playerHealth;
            _flip = flip;
            _isPlayerRightSide = isPlayerRightSide;
        }

        public void OnEnter()
        {
            _currentAttackTime = 0f;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _maxAttackTime)
            {
                _flip.FlipCharacter(_isPlayerRightSide.Invoke() ? 1f : -1f);

                _animation.AttackAnimation();
                _attacker.Attack(_playerHealth);
                _currentAttackTime = 0f;
            }

            //Debug.Log("Attack Tick");
        }
    }
}