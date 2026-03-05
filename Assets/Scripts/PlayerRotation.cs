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
    private RotationDirection rotationDirection = RotationDirection.Left;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if ( playerRigidbody.linearVelocity != Vector2.zero )
        {
            if( rotationDirection == RotationDirection.Left )
            {
                playerRigidbody.rotation += 0.2f;

                if (playerRigidbody.rotation > 10f)
                {
                    rotationDirection = RotationDirection.Right;
                }
            }

            if (rotationDirection == RotationDirection.Right)
            {
                playerRigidbody.rotation -= 0.2f;

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
