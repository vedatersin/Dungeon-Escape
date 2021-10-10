using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.Movements
{
    public class FlipWithSpriteRender : IFlip
    {
        SpriteRenderer _spriteRenderer;

        public FlipWithSpriteRender(PlayerController player)
        {
            _spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        }

        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            if (direction < 0f)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
