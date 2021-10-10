using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstracts.Movements
{
    public interface IJump
    {
        void TickWithFixedUpdate();
        bool IsJump { get; set; }
    }
}