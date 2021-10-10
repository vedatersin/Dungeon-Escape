using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Managers;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] int scorePoint = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                GameManager.Instance.IncreaseScore(scorePoint);
                Destroy(this.gameObject);
            }
        }
    }
}