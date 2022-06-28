using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUp : PowerUp
{
    public float MultiplySpeedBy = 2;

    public override string Name => "Ball Speed Up";

    public override void OnPowerUpTouched(GameObject ball)
    {
        ball.GetComponent<BallController>().ActivateBallSpeedUp(MultiplySpeedBy, _powerUpManager.PowerUpDuration);
    }

    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }
}
