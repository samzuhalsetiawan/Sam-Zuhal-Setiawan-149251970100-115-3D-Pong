using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinnerPodiumManager : MonoBehaviour
{
    public GameObject winnerLabel;

    // Start is called before the first frame update
    void Start()
    {
        Text winnerName = winnerLabel.GetComponent<Text>();
        switch (SharedPref.Winner)
        {
            case Player.P1:
                winnerName.text = "Player 1";
                winnerName.color = Color.blue;
                break;
            case Player.P2:
                winnerName.text = "Player 2";
                winnerName.color = Color.green;
                break;
            case Player.P3:
                winnerName.text = "Player 3";
                winnerName.color = Color.red;
                break;
            case Player.P4:
                winnerName.text = "Player 4";
                winnerName.color = Color.yellow;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }
}
