using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 startPos;
    public float speed;
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

    public void BallSpeed(int value)
    {
        if (value == -1 && speed > 3)
            speed -= 1;
        if (value == 1 && speed < 9)
            speed += 1;
    }

    public float GetY_ball()
    {
        return rb.velocity.y;
    }
}
