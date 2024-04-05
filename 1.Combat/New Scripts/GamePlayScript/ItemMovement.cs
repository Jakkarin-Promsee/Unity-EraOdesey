using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Transform player;  
    public float acceleration = 1f;  
    public float maxSpeed = 5f;  

    private Rigidbody2D rb;  

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Vector3 newPosition = transform.position;
        newPosition.y += 0.3f;
        transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        if (player != null)
        {    
            Vector2 direction = player.position - transform.position;
        
            direction.Normalize();
    
            Vector2 accelerationVector = direction * acceleration;

            rb.velocity += accelerationVector * Time.fixedDeltaTime;

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}