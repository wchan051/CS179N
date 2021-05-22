using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;
namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public bool attack;
        bool climb;
        private Animator m_Anim;
        public bool jumping;
        public bool grounded;
        public bool crouch;

        bool downJumping = false;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_Anim = GetComponent<Animator>();
            jumping= Input.GetKeyDown(KeyCode.LeftAlt);
        }


        private void Update()
        {
            crouch = Input.GetKey(KeyCode.DownArrow);
            attack = Input.GetKey(KeyCode.LeftControl);
            grounded = m_Anim.GetBool("Ground");
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            /*if (grounded && crouch && m_Jump && !downJumping)
            {
                StartCoroutine("downJump");
            }*/

        }


        private void FixedUpdate()
        {
            // Read the inputs.
             
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
             

            m_Character.Move(h, crouch, m_Jump, attack);

            

            m_Jump = false;
        }

        /*IEnumerator downJump()
        {
            downJumping = true;
            Physics2D.IgnoreLayerCollision(3, 2, true);
            yield return new WaitForSeconds(0.5f);
            Physics2D.IgnoreLayerCollision(3, 2, false);
            downJumping = false;
        }*/

    }
}
