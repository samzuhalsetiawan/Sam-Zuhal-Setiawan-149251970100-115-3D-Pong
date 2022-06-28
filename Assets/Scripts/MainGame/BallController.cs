using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 startImpulse;

    private Rigidbody _rigidbody;
    private GameObject _lastHitPaddle;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        //_rigidbody.velocity = startImpulse;
        _rigidbody.AddForce(startImpulse, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MultiplyVelocityBy(float amount)
    {
        _rigidbody.velocity *= amount;
    }

    public void DevideVelocityBy(float amount)
    {
        _rigidbody.velocity /= amount;
    }

    public void MultiplyBallSizeBy(float amount)
    {
        transform.localScale *= amount;
    }

    public void DevideBallSizeBy(float amount)
    {
        transform.localScale /= amount;
    }

    public GameObject GetLastHitPaddle()
    {
        return _lastHitPaddle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            _lastHitPaddle = collision.gameObject;
        }
    }

    public void ActivateBallSpeedUp(float amount, float lifeTime)
    {
        MultiplyVelocityBy(amount);
        StartCoroutine(deactivateBallSpeedUp(amount, lifeTime));
    }

    public IEnumerator deactivateBallSpeedUp(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            DevideVelocityBy(amount);
        }
        catch
        {
            Debug.LogWarning("[BallController] Cannot purify power up: Ball Speed Up, object already destroyed");
        }
    }

    public void ActivateBallExtend(float amount, float lifeTime)
    {
        MultiplyBallSizeBy(amount);
        StartCoroutine(DeactivateBallExtend(amount, lifeTime));
    }

    public IEnumerator DeactivateBallExtend(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            DevideBallSizeBy(amount);
        }
        catch
        {
            Debug.LogWarning("[BallController] Cannot purify power up: Ball Extend, object already destroyed");
        }
    }

    public void ActivateBallCollapse(float amount, float lifeTime)
    {
        DevideBallSizeBy(amount);
        StartCoroutine(DeactivateBallCollapse(amount, lifeTime));
    }

    public IEnumerator DeactivateBallCollapse(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            MultiplyBallSizeBy(amount);
        }
        catch
        {
            Debug.LogWarning("[BallController] Cannot purify power up: Ball Shrink, object already destroyed");
        }
    }
}
