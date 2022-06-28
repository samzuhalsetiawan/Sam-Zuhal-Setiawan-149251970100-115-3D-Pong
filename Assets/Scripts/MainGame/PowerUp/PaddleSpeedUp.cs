using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSpeedUp : PowerUp
{
    public override string Name => "Paddle Speed Up";

    public float MultiplyPaddleSpeedBy;

    public override void OnPowerUpTouched(GameObject ball)
    {
        GameObject paddle = ball.GetComponent<BallController>().GetLastHitPaddle();
        if (paddle != null)
        {
            paddle.GetComponent<PaddleController>().ActivatePaddleSpeedUp(MultiplyPaddleSpeedBy, _powerUpManager.PowerUpDuration);
        }
    }
    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
