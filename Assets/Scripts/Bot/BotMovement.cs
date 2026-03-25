using UnityEngine;

enum Direction
{
    Right,
    Left
}

public class Bot : MonoBehaviour
{
    Direction direction = Direction.Right;
    
    float timer;
    [SerializeField] private float speed;

    float moving_duration = 1f;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {

        if (direction == Direction.Right)
        {
            if (timer < moving_duration)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                timer += Time.deltaTime;
            }
            else
            {
                direction = Direction.Left;
                timer = 0f;
            }
        }

        
        if (direction == Direction.Left)
        {
            if(timer < moving_duration)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                timer += Time.deltaTime;
            }
            else
            {
                direction = Direction.Right;
                timer = 0f;
            }
        }
        
    }
}
