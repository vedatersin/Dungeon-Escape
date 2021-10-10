using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UnityEngine;

namespace UdemyProject3.Movements
{
    public class Jump : IJump
    {
        float jumpForce = 350f;
        Rigidbody2D _rigidbody;
        IOnGround _onGround;

        public bool IsJump { get; set; }

        public Jump(Rigidbody2D rigidbody, IOnGround onGround)
        {
            _rigidbody = rigidbody;
            _onGround = onGround;
        }

        public void TickWithFixedUpdate()
        {
            if (IsJump && _onGround.IsGround)
            {
                _rigidbody.velocity = Vector2.zero;

                _rigidbody.AddForce(Vector2.up * jumpForce);

                _rigidbody.velocity = Vector2.zero;
            }

            IsJump = false;
        }
    }
}