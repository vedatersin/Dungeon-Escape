using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject3.StateMachines.EnemyStates
{
    public class Dead : IState
    {
        IMyAnimation _animation;
        IEntityController _controller;
        System.Action _deadCallBack;

        float _currentTime = 0f;

        public Dead(IEntityController controller, IMyAnimation animation, System.Action deadCallBack)
        {
            _animation = animation;
            _controller = controller;
            _deadCallBack = deadCallBack;
        }

        public void OnEnter()
        {
            _animation.DeadAnimation();
            _deadCallBack?.Invoke();
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > 5f)
            {
                Object.Destroy(_controller.transform.gameObject);
            }

            //Debug.Log("Dead Tick");
        }
    }
}