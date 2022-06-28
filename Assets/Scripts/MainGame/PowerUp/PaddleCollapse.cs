using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCollapse : PowerUp
{
    public override string Name => "Paddle Shrink";

    public float ShrinkPaddleBy;

    public override void OnPowerUpTouched(GameObject ball)
    {
        GameObject lastHitPaddle =  ball.GetComponent<BallController>().GetLastHitPaddle();
        if (lastHitPaddle != null)
        {
            lastHitPaddle.GetComponent<PaddleController>().ActivatePaddleCollapse(ShrinkPaddleBy, _powerUpManager.PowerUpDuration);
        }
    }
    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
