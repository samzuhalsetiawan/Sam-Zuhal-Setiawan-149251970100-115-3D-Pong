using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSlowDown : PowerUp
{
    public override string Name => "Paddle Slow Down";

    public float SlowDownPaddleBy;

    public override void OnPowerUpTouched(GameObject ball)
    {
        GameObject lastHitPaddle = ball.GetComponent<BallController>().GetLastHitPaddle();
        if (lastHitPaddle != null)
        {
            lastHitPaddle.GetComponent<PaddleController>().ActivatePaddleSlowDown(SlowDownPaddleBy, _powerUpManager.PowerUpDuration);
        }
    }
    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
