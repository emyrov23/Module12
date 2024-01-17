using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float speed = 2.0f;
        private Rigidbody playerRigitBody;

        private void Awake()
        {
            playerRigitBody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            playerRigitBody.AddForce(movement * speed);            
        }

        public void ResetMovement()
        {
            playerRigitBody.isKinematic = true;
            playerRigitBody.isKinematic = false;
        }

#if UNITY_EDITOR
        [ContextMenu("Reset values")]

        public void ResetValues()
        {
            speed = 2;
        }
#endif
    
    }
}