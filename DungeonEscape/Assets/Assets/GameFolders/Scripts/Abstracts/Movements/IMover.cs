using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstracts.Movements
{
    public interface IMover
    {
        void Tick(float horizontal);
    }
}