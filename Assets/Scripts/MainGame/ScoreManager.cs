using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _scoreP1 = 0;
    private int _scoreP2 = 0;
    private int _scoreP3 = 0;
    private int _scoreP4 = 0;
    private GameObject _gameManagerObject;
    private GameManager _gameManager;
    private WallManager _wallManager;

    public int InitialScore = 150;
    public int KebobolanValue = 10;
    public Text ScorePlayer1;
    public Text ScorePlayer2;
    public Text ScorePlayer3;
    public Text ScorePlayer4;
    // Start is called before the first frame update
    void Start()
    {
        _scoreP1 = InitialScore;
        _scoreP2 = InitialScore;
        _scoreP3 = InitialScore;
        _scoreP4 = InitialScore;
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = _gameManagerObject.GetComponent<GameManager>();
        _wallManager = _gameManagerObject.GetComponent<WallManager>();
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Kebobolan(Player player, GameObject ball)
    {
        switch(player)
        {
            case Player.P1:
                if (_scoreP1 <= 0) break;
                _scoreP1 -= KebobolanValue;
                if (_scoreP1 <= 0)
                {
                    _gameManager.KeluarkanPemain(player);
                    _wallManager.RiseWallPlayer(player);
                }
                break;
            case Player.P2:
                if (_scoreP2 <= 0) break;
                _scoreP2 -= KebobolanValue;
                if (_scoreP2 <= 0)
                {
                    _gameManager.KeluarkanPemain(player);
                    _wallManager.RiseWallPlayer(player);
                }
                break;
            case Player.P3:
                if (_scoreP3 <= 0) break;
                _scoreP3 -= KebobolanValue;
                if (_scoreP3 <= 0)
                {
                    _gameManager.KeluarkanPemain(player);
                    _wallManager.RiseWallPlayer(player);
                }
                break;
            case Player.P4:
                if (_scoreP4 <= 0) break;
                _scoreP4 -= KebobolanValue;
                if (_scoreP4 <= 0)
                {
                    _gameManager.KeluarkanPemain(player);
                    _wallManager.RiseWallPlayer(player);
                }
                break;
        }
        _gameManager.HapusBola(ball);
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        ScorePlayer1.text = _scoreP1.ToString();
        ScorePlayer2.text = _scoreP2.ToString();
        ScorePlayer3.text = _scoreP3.ToString();
        ScorePlayer4.text = _scoreP4.ToString();
    }

}
