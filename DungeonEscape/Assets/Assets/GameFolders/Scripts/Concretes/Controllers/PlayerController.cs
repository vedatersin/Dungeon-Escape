using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Inputs;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Animations;
using UdemyProject3.Inputs;
using UdemyProject3.Managers;
using UdemyProject3.Movements;
using UdemyProject3.Uis;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] float moveSpeed = 3f;

        IPlayerInput _input;
        IMover _mover;
        IMyAnimation _animation;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        IHealth _health;
         
        float _horizontal;

        private void Awake()
        {
            _input = new MobileInput();
            _mover = new MoverWithTranslate(this, moveSpeed);
            _animation = new CharacterAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _onGround = GetComponent<IOnGround>();
            _jump = new Jump(GetComponent<Rigidbody2D>(),_onGround);
            _health = GetComponent<IHealth>();
        }

        private void OnEnable()
        {
            _health.OnDead += _animation.DeadAnimation;
            _health.OnDead += GameManager.Instance.SaveScore;
        }

        private void Start()
        {
            GameOverObject gameOverObject = FindObjectOfType<GameOverObject>();
            gameOverObject.SetPlayerHealth(_health);
        }

        private void Update()
        {
            if (_health.IsDead) return;

            _horizontal = _input.Horizontal;

            if (_input.AttackButtonDown && _horizontal == 0f)
            {
                _animation.AttackAnimation();
                return;
            }

            if (_input.JumpButtonDown)
            {
                _jump.IsJump = true;
            }

            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }

        private void FixedUpdate()
        {
            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);

            _jump.TickWithFixedUpdate();
        }
    }
}