using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.Uis
{
    public class ShopGameObject : MonoBehaviour
    {
        [SerializeField] QuestionPanel questionPanel;
        [SerializeField] GameObject shop;

        IHealth _playerHealth;

        private void OnEnable()
        {
            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void OnDisable()
        {
            _playerHealth = null;
        }

        public void BuyLifeClick(int lifeCount)
        {
            questionPanel.gameObject.SetActive(true);
            questionPanel.SetLifeCountAndReferances(lifeCount,_playerHealth);
        }

        public void IsActiveShop(bool isActive)
        {
            shop.SetActive(isActive);
            Debug.Log(isActive);
        }
    }
}