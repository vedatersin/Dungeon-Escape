using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject3.Uis
{
    public class GameOverObject : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;

        IHealth _playerHealth;

        private void OnEnable()
        {
            gameOverPanel.SetActive(false);
            
        }

        private void OnDisable()
        {
            _playerHealth.OnDead -= HandleDead;
        }

        public void SetPlayerHealth(IHealth health)
        {
            _playerHealth = health;
            _playerHealth.OnDead += HandleDead;
        }

        private void HandleDead()
        {
            StartCoroutine(GameOver());
        }

        private IEnumerator GameOver()
        {
            yield return new WaitForSeconds(1.5f);
            gameOverPanel.SetActive(true);
        }
    }
}