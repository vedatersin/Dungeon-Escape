using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Enums;
using UdemyProject3.Managers;
using UnityEngine;

namespace UdemyProject3.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Game);
        }

        public void NoButton()
        {
            GameManager.Instance.SplashScreen(SceneTypeEnum.Menu);
        }
    }
}