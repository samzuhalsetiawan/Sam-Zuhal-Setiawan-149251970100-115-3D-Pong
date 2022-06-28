using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    protected GameObject _gameManagerObject;
    protected PowerUpManager _powerUpManager;

    private void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _powerUpManager = _gameManagerObject.GetComponent<PowerUpManager>();
    }

    public abstract string Name { get; }

    public abstract void OnPowerUpTouched(GameObject ball);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            OnPowerUpTouched(other.gameObject);
            _powerUpManager.RemovePowerUp(gameObject);
        }
    }
}
