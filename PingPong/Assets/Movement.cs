using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool player1, vsAI;
    public float speed;
    public Vector3 startPos;

    public GameObject ball, gameManager, playerInfo;

    public SoundManager soundManager;

    Rigidbody2D rb;
    float movement;
    float yBot;

    private void Start()
    {
        updateInfo();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        yBot = ball.GetComponent<Ball>().GetY_ball();

        if (player1)
        {
            movement = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
            if(vsAI)
                rb.velocity = new Vector2(rb.velocity.x, Mathf.MoveTowards(rb.velocity.y, yBot, speed * 3 * Time.deltaTime));
            else
                rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }

    public void Variety(int i, int plNo)
    {
        switch (i)
        {
            case 1:
                gameManager.GetComponent<GameManager>().EffectText("speed up", plNo);
                if(speed < 7)
                    speed += 1;
                break;
            case 2:
                gameManager.GetComponent<GameManager>().EffectText("speed down", plNo);
                if(speed > 1)
                    speed -= 1;
                break;
            case 3:
                gameManager.GetComponent<GameManager>().EffectText("BIG BIGGER THE BIGGEST!", plNo);
                if (transform.localScale.y < 6)
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 1);
                break;
            case 4:
                gameManager.GetComponent<GameManager>().EffectText("little cow", plNo);
                if (transform.localScale.y > 1)
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - 1);
                break;
            case 5:
                gameManager.GetComponent<GameManager>().EffectText("WALLLLLY!", plNo);
                gameManager.GetComponent<GameManager>().Add_wall();
                break;
            case 6:
                gameManager.GetComponent<GameManager>().EffectText("jet BALL!", plNo);
                ball.GetComponent<Ball>().BallVariety(1);
                break;
            case 7:
                gameManager.GetComponent<GameManager>().EffectText("snail ball", plNo);
                ball.GetComponent<Ball>().BallVariety(2);
                break;
            case 8:
                gameManager.GetComponent<GameManager>().EffectText("GROW UP!", plNo);
                ball.GetComponent<Ball>().BallVariety(3);
                break;
            case 9:
                gameManager.GetComponent<GameManager>().EffectText("tiny shy ball :)", plNo);
                ball.GetComponent<Ball>().BallVariety(4);
                break;
        }
    }

    public void updateInfo()
    {
        playerInfo.GetComponent<TextMeshProUGUI>().text = "speed: " + speed + "\nscale: " + transform.localScale.y;
    }
}
