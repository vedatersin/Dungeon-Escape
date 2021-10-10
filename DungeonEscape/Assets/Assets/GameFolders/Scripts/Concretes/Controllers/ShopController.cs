using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Uis;
using UnityEngine;

namespace UdemyProject3.Controllers
{
    public class ShopController : MonoBehaviour
    {
        ShopGameObject _shopGameObject;

        private void Start()
        {
            _shopGameObject = FindObjectOfType<ShopGameObject>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IsPlayerTriggered(collision, true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsPlayerTriggered(collision, false); 
        }

        private void IsPlayerTriggered(Collider2D colider, bool isActive)
        {
            PlayerController player = colider.GetComponent<PlayerController>();

            if (player != null)
            {
                _shopGameObject.IsActiveShop(isActive);
            }
        }
    }
}