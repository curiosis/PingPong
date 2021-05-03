using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ball, player1, player1Goal, Player1Text, Player1Effect;
    public GameObject player2, player2Goal, Player2Text, Player2Effect;
    int Player1Score, Player2Score;

    public GameObject gameInfo, winPanel, line, winner;

    public GameObject addWallT, addWallB;
    System.Random rnd = new System.Random();

    public GameObject infoPanel;

    private void Start()
    {
        updateGameInfo();
        Player1Effect.GetComponent<TextMeshProUGUI>().text = "no effect";
        Player2Effect.GetComponent<TextMeshProUGUI>().text = "no effect";
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
            infoPanel.SetActive(true);
        else
            infoPanel.SetActive(false);

        if (Player1Score == 5)
            EndGame(1);
        else if (Player2Score == 5)
            EndGame(0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void EndGame(int i)
    {
        if(i == 1)
            winner.GetComponent<TextMeshProUGUI>().text = "Player 1\nWON!";
        else
            winner.GetComponent<TextMeshProUGUI>().text = "Player 2\nWON!";

        winPanel.SetActive(true);
        line.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        ball.SetActive(false);
        Player1Effect.SetActive(false);
        Player2Effect.SetActive(false);
        Player1Text.SetActive(false);
        Player2Text.SetActive(false);
    }

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
        player1.GetComponent<Movement>().Variety(rnd.Next(1, 11), 1);
        player2.GetComponent<Movement>().Variety(rnd.Next(1, 11), 2);
        player1.GetComponent<Movement>().updateInfo();
        player2.GetComponent<Movement>().updateInfo();
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Movement>().Reset();
        player2.GetComponent<Movement>().Reset();
    }

    public void Add_wall()
    {
        if (addWallT.activeSelf)
        {
            addWallT.SetActive(false);
            addWallB.SetActive(false);
        }
        else
        {
            addWallT.SetActive(true);
            addWallB.SetActive(true);
        }
    }

    public void EffectText(String effectText, int playerNo)
    {
        if(playerNo == 1)
            Player1Effect.GetComponent<TextMeshProUGUI>().text = effectText;
        else
            Player2Effect.GetComponent<TextMeshProUGUI>().text = effectText;
        updateGameInfo();
    }

    void updateGameInfo()
    {
        gameInfo.GetComponent<TextMeshProUGUI>().text = "ball scale: " + ball.GetComponent<Ball>().gameObject.transform.localScale.x + "\nball speed: " + ball.GetComponent<Ball>().speed + "\nadd wall: " + addWallT.activeSelf;
    }
}
