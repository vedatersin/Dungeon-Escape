using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Controllers;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.Movements
{
    public class FlipWithTransform : IFlip
    {
        IEntityController _entity;

        public FlipWithTransform(IEntityController entity)
        {
            _entity = entity;
        }

        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            float mathValue = Mathf.Sign(direction);

            if (mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}