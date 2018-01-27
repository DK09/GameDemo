using System;
using UnityEngine;


[RequireComponent(typeof (PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;


    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        if (GameManager.Instance.pause) return;
        // Read the inputs.
        //bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = Input.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, false, m_Jump);
        m_Jump = false;
    }
}