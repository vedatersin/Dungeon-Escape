using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Enums;
using UdemyProject3.Managers;
using UnityEngine;

namespace UdemyProject3.Uis
{
    /// <summary>
    /// Menu Panel içindeki ButtonObjects'e ait bir component'tir. Component'in amacı Menu içinde start ve quit methodları için yazılmıştır.
    /// </summary>

    public class MenuButtonObject : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }

        public void QuitGame()
        {
            GameManager.Instance.QuitGame();
        }
    }
}