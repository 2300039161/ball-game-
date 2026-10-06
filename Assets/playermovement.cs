using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            move = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            move = 1f;

        float nextX = transform.position.x + move * speed * Time.deltaTime;

        // Keeps the full player bar inside walls at X -9.6 and X 9.63.
        nextX = Mathf.Clamp(nextX, -8.4f, 8.4f);

        transform.position = new Vector3(nextX, -4f, 0f);
    }
}