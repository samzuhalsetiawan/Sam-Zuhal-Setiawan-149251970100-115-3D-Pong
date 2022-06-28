using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private List<GameObject> _spawnedBalls = new();
    private float _ballSpawnTimer;
    private List<Player> _playersPodium = new();
    private List<Player> _activePlayer = new List<Player> { Player.P1, Player.P2, Player.P3, Player.P4 };

    public Vector3 ArenaMaxSize;
    public Vector3 ArenaMinSize;
    public float initialPaddleSpeed;
    public int MaxBallInArena;
    public int BallSpawnInterval;
    public GameObject BallPrefab;
    public Transform BallSpawnArea;
    public List<Vector3> SpawnPointList;
    // Start is called before the first frame update
    void Start()
    {
        _ballSpawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _ballSpawnTimer += Time.deltaTime;
        if (_ballSpawnTimer > BallSpawnInterval)
        {
            SpawnBall();
            _ballSpawnTimer -= BallSpawnInterval;
        }
    }

    public bool HapusBola(GameObject ball)
    {
        try
        {
            Destroy(ball);
            _spawnedBalls.Remove(ball);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public void KeluarkanPemain(Player player)
    {
        GameObject[] paddleList = GameObject.FindGameObjectsWithTag("Paddle");
        foreach(GameObject paddle in paddleList)
        {
            if (paddle.GetComponent<PaddleController>().player == player)
            {
                Destroy(paddle);
            }
        }
        _playersPodium.Add(player);
        _activePlayer.Remove(player);
        if (_playersPodium.Count == 3)
        {
            _playersPodium.Add(_activePlayer[0]);
            SharedPref.Winner = _activePlayer[0];
            SceneManager.LoadScene(2);
        }
    }

    public void SpawnBall()
    {
        if (_spawnedBalls.Count < MaxBallInArena)
        {
            int randomIndex = Random.Range(0, 4);
            GameObject ball = Instantiate(BallPrefab, SpawnPointList[randomIndex], Quaternion.identity, BallSpawnArea);
            bool genap = Random.Range(1, 3) % 2 == 0;
            switch(randomIndex)
            {
                case 0:
                    ball.GetComponent<BallController>().startImpulse = new Vector3(genap ? -4f : Random.Range(0f, -4f), 0, genap ? Random.Range(0f, -4f) : -4);
                    break;
                case 1:
                    ball.GetComponent<BallController>().startImpulse = new Vector3(genap ? -4f : Random.Range(0f, -4f), 0, genap ? Random.Range(0f, 4f) : 4f);
                    break;
                case 2:
                    ball.GetComponent<BallController>().startImpulse = new Vector3(genap ? 4f : Random.Range(0f, 4f), 0, genap ? Random.Range(0f, -4f) : -4f);
                    break;
                case 3:
                    ball.GetComponent<BallController>().startImpulse = new Vector3(genap ? 4f : Random.Range(0f, 4f), 0, genap ? Random.Range(0f, 4f) : 4f);
                    break;
            }
            ball.SetActive(true);
            _spawnedBalls.Add(ball);
        }
    }
}
