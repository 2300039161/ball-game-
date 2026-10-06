using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;

    float bounceSpeed = 8f;
    float maximumSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Initial fall.
        rb.velocity = new Vector2(Random.Range(-3f, 3f), -3f);
    }

    void Update()
    {
        if (!GameManager.gameOver && transform.position.y < -6f)
        {
            GameManager.gameOver = true;
            rb.simulated = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce from walls.
        Vector2 normal = collision.GetContact(0).normal;
        rb.velocity = Vector2.Reflect(rb.velocity, normal);

        // Catching the ball increases its speed.
        if (collision.gameObject.name == "player")
        {
            GameManager.score++;

            bounceSpeed = Mathf.Min(bounceSpeed * 1.1f, maximumSpeed);

            float sidewaysSpeed = Random.Range(-bounceSpeed * 0.5f, bounceSpeed * 0.5f);
            rb.velocity = new Vector2(sidewaysSpeed, bounceSpeed);
        }
    }
}