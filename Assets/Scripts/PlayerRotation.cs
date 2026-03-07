using UnityEngine;
using UnityEngine.InputSystem;

enum RotationDirection
{ 
    Left,
    Right
}

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float wobbleSpeed;
    [SerializeField] private float wobbleSprintSpeed;
    private RotationDirection rotationDirection = RotationDirection.Left;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( playerRigidbody.linearVelocity != Vector2.zero )
        {
            if( rotationDirection == RotationDirection.Left )
            {
                if (PlayerMovement.isSprinting)
                {
                    playerRigidbody.rotation += wobbleSprintSpeed * Time.deltaTime;
                }
                else
                {
                    playerRigidbody.rotation += wobbleSpeed * Time.deltaTime;
                }

                if (playerRigidbody.rotation > 10f)
                {
                    rotationDirection = RotationDirection.Right;
                }
            }

            if (rotationDirection == RotationDirection.Right)
            {
                if (PlayerMovement.isSprinting)
                {
                    playerRigidbody.rotation -= wobbleSprintSpeed * Time.deltaTime;
                }
                else
                {
                    playerRigidbody.rotation -= wobbleSpeed * Time.deltaTime;
                }

                if (playerRigidbody.rotation < -10f)
                {
                    rotationDirection = RotationDirection.Left;
                }
            }
        }
        else
        {
            playerRigidbody.rotation = 0f;
        }
        
    }
}
