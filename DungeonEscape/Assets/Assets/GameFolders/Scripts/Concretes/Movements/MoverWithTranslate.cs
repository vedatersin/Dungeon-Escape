using UdemyProject3.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdemyProject3.Controllers;
using UdemyProject3.Abstracts.Controllers;

namespace UdemyProject3.Movements
{
    public class MoverWithTranslate : IMover
    {
        IEntityController _controller;
        float _moveSpeed;

        public MoverWithTranslate(IEntityController controller, float moveSpeed)
        {
            _controller = controller;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            if (horizontal == 0) return;

            _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
        }
    }
}
