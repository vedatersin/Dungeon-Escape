using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject3.StateMachines.EnemyStates
{
    public class Walk : IState
    {
        IMover _mover;
        IMyAnimation _animation;
        IEntityController _entityController;
        IFlip _flip;

        float _direction;
        int _patrolIndex = 0;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController, IMover mover, IMyAnimation animation, IFlip flip, params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _entityController = entityController;
            _patrols = patrols;
            _flip = flip;
        }

        public void OnEnter()
        {
            if (_patrols.Length < 1) return;

            _currentPatrol = _patrols[_patrolIndex];
            
            Vector3 leftOrRight = _currentPatrol.position - _entityController.transform.position;

            _flip.FlipCharacter(leftOrRight.x > 0f ? 1f : -1f);

            _direction = _entityController.transform.localScale.x;

            _animation.MoveAnimation(1f);

            IsWalking = true;
        }

        public void OnExit()
        {
            _animation.MoveAnimation(0f);

            _patrolIndex++;

            if (_patrolIndex >= _patrols.Length)
            {
                _patrolIndex = 0;
            }
        }

        public void Tick()
        {
            if (_currentPatrol == null) return;

            if (Vector2.Distance(_entityController.transform.position, _currentPatrol.position) <= 0.25f)
            {
                IsWalking = false;
                return;
            }

            _mover.Tick(_direction);
            //Debug.Log("Walk Tick");
        }
    }
}