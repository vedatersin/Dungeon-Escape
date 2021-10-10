using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Inputs;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UdemyProject3.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => CrossPlatformInputManager.GetAxis("Horizontal");

        public float Vertical => CrossPlatformInputManager.GetAxis("Vertical");

        public bool JumpButtonDown => CrossPlatformInputManager.GetButtonDown("Jump");

        public bool AttackButtonDown => CrossPlatformInputManager.GetButtonDown("Fire1");
    }
}