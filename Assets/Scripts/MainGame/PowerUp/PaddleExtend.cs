using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleExtend : PowerUp
{
    public override string Name => "Paddle Extend";

    public float ExtendPaddleBy;

    public override void OnPowerUpTouched(GameObject ball)
    {
        GameObject lastHitPaddle = ball.GetComponent<BallController>().GetLastHitPaddle();
        if (lastHitPaddle != null)
        {
            lastHitPaddle.GetComponent<PaddleController>().ActivatePaddleExtend(ExtendPaddleBy, _powerUpManager.PowerUpDuration);
        }
    }
    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
