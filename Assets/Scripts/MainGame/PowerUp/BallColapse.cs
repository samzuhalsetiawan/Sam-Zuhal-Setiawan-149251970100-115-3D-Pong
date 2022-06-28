using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColapse : PowerUp
{
    public override string Name => "Ball Shrink";

    public float shrinkingSize;

    public override void OnPowerUpTouched(GameObject ball)
    {
        ball.GetComponent<BallController>().ActivateBallCollapse(shrinkingSize, _powerUpManager.PowerUpDuration);
    }
    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
