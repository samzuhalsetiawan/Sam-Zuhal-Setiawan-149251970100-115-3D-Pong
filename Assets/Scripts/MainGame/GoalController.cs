using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private GameObject _gameManagerObject;
    private ScoreManager _scoreManager;

    public Player goalPlayer;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _scoreManager = _gameManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            _scoreManager.Kebobolan(goalPlayer, collision.gameObject);
        }
    }
}
