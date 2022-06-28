using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private GameObject _gameManagerObject;
    private WallManager _wallManager;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _wallManager = _gameManagerObject.GetComponent<WallManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartRiseWall()
    {
        InvokeRepeating(nameof(RiseWall), 0f, Time.deltaTime);
    }

    public void RiseWall()
    {
        transform.Translate(0, _wallManager.riseWallSpeed, 0);
        if (transform.position.y >= _wallManager.riseWallHeight) CancelInvoke(nameof(RiseWall));
    }
}
