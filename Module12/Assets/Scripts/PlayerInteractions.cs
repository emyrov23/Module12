using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace WildBall.Inputs
{
    public class PlayerInteractions : MonoBehaviour
    {
        public Canvas canvas;
        public GameObject Door;
        public bool onGround = false;
        private SelectLevel selectLevel;

        private void Awake()
        {
            selectLevel = GetComponent<SelectLevel>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Hint"))
            {
                ActivatedPanel(canvas, "HintPanel", true);
            }
            else if (other.CompareTag("Finish"))
            {
                ActivatedPanel(canvas, "FinishPanel", true);
                Time.timeScale = 0f;
            }
            else if(other.CompareTag("Jump"))
            {
                ActivatedPanel(canvas, "JumpPanel", true);
                onGround = true;
            }
            else if(other.CompareTag("Lava"))
            {
                selectLevel.ReloadScene();
            }
        }

        /// <summary>
        /// Активация/деактивация элемента в Canvas
        /// </summary>
        /// <param name="_canvas">Canvas</param>
        /// <param name="_name">Имя искомого элемента</param>
        /// <param name="_condition">Состояние</param>
        private void ActivatedPanel(Canvas _canvas, string _name, bool _condition)
        {
            foreach (var el in _canvas.GetComponentsInChildren<RectTransform>(true))
            {
                if (el.name == _name)
                {
                    (el as RectTransform).gameObject.SetActive(_condition);
                    break;
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Door"))
            {
                ActivatedPanel(canvas, "InteractionPanel", true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Door.GetComponent<Rigidbody>().isKinematic = false;
                    Door.GetComponent<Animator>().enabled = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Hint"))
            {
                ActivatedPanel(canvas, "HintPanel", false);
            }
            else if (other.CompareTag("Door"))
            {
                ActivatedPanel(canvas, "InteractionPanel", false);
            }
            else if (other.CompareTag("Jump"))
            {
                ActivatedPanel(canvas, "JumpPanel", false);
                onGround = false;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (CompareTag("Barier"))
            {
                {
                    ActivatedPanel(canvas, "DestroyPanel", true);
                }
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (CompareTag("Barier"))
            {
                ActivatedPanel(canvas, "DestroyPanel", false);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (CompareTag("Barier"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    collision.gameObject.SetActive(false);
                    ActivatedPanel(canvas, "DestroyPanel", false);
                }
            }
        }
    }
}
