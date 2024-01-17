using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scene = UnityEngine.SceneManagement.Scene;

namespace WildBall.Inputs
{
    public class SelectLevel : MonoBehaviour
    {
        private Scene activeScene;

        private void Awake()
        {
            activeScene = SceneManager.GetActiveScene();
        }

        public void SelectedLevel(Button _button)
        {
            SceneManager.LoadScene(_button.tag.ToString());
            Time.timeScale = 1f;
        }

        public void GoToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(activeScene.name);
            Time.timeScale = 1f;
        }
    }
}