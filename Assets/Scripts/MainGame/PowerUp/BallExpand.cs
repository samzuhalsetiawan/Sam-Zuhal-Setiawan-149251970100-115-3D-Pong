using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExpand : PowerUp
{
    public float MultiplyBallSizeBy;
    public override string Name => "Ball Expanded";

    public override void OnPowerUpTouched(GameObject ball)
    {
        ball.GetComponent<BallController>().ActivateBallExtend(MultiplyBallSizeBy, _powerUpManager.PowerUpDuration);
    }

    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
