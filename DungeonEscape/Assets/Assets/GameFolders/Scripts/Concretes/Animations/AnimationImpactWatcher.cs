using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Animations
{
    public class AnimationImpactWatcher : MonoBehaviour
    {
        public event System.Action OnImpact;   // Player Attack Animation Event

        public void Impact()
        {
            OnImpact?.Invoke();
        }
    }
}

