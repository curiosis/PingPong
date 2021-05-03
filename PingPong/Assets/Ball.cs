using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPos;
    public float speed;
    public bool mainBall;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void Launch()
    {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            float y = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Launch();
    }

    public float GetY_ball()
    {
        return rb.velocity.y;
    }

    public void BallVariety(int value)
    {
        switch (value)
        {
            case 1:
                if (speed > 3)
                    speed -= 1;
                break;
            case 2:
                if (speed < 9)
                    speed += 1;
                break;
            case 3:
                if (transform.localScale.y < 1.0f)
                    transform.localScale = new Vector3(transform.localScale.x + 0.15f, transform.localScale.y + 0.15f);
                break;
            case 4:
                if (transform.localScale.y > 0.05f)
                    transform.localScale = new Vector3(transform.localScale.x - 0.15f, transform.localScale.y - 0.15f);
                break;
        }
    }
}
