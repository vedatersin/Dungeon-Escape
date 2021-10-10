using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstracts.Animations
{
    public interface IMyAnimation
    {
        void MoveAnimation(float moveSpeed);
        void JumpAnimation(bool isJump);
        void AttackAnimation();
        void TakeHitAnimation();
        void DeadAnimation();
    }
}