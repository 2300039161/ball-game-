using UnityEngine;

public class BallReset : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6f)
            ResetBall();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ResetBall();
    }

    void ResetBall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        float randomX = Random.Range(-7f, 7f);
        transform.position = new Vector3(randomX, 5f, 0f);
    }
}