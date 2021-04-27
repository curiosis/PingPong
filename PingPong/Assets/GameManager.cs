using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball, player1, player1Goal, Player1Text;
    public GameObject player2, player2Goal, Player2Text;
    int Player1Score, Player2Score;

    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetPosition();
    }

    void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Movement>().Reset();
        player2.GetComponent<Movement>().Reset();
    }
}
