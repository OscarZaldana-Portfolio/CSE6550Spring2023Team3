using UnityEngine;

public class LeafController : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position;

        if (newPos.x < -5f) // left boundary
        {
            newPos.x = -5f;
        }
        else if (newPos.x > 5f) // right boundary
        {
            newPos.x = 5f;
        }

        if (newPos.y < -3f) // bottom boundary
        {
            newPos.y = -3f;
        }
        else if (newPos.y > 3f) // top boundary
        {
            newPos.y = 3f;
        }

        rb.MovePosition(newPos);
    }
}
