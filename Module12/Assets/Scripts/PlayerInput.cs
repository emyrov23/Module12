using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 movement;
        private Vector3 _jumpVector;
        [SerializeField, Range(0, 10)] private float JumpSpeed = 2.0f;
        private PlayerMovement playerMovement;
        private PlayerInteractions playerInteractions;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerInteractions = GetComponent<PlayerInteractions>();
        }

        void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);
            movement = new Vector3(horizontal, 0, vertical);
            float jumpValue = 25;
            if (Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON))
            {
                if (playerInteractions.onGround)
                {
                    _jumpVector = new Vector3(0, jumpValue * JumpSpeed, 0);
                    playerMovement.MoveCharacter(_jumpVector);
                }
            }
            else
            {
                movement = new Vector3(horizontal, 0, vertical);
            }
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(movement);
        }
    }

}