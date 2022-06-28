using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float _paddleSpeed;
    private Rigidbody _rb;

    public KeyCode LeftKey;
    public KeyCode RightKey;
    public Player player;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _paddleSpeed = gameManager.initialPaddleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        switch(player)
        {
            case Player.P1:
                UpdateMove(new Vector3(-1, 0, 0), new Vector3(1, 0, 0));
                break;
            case Player.P2:
                UpdateMove(new Vector3(0, 0, 1), new Vector3(0, 0, -1));
                break;
            case Player.P3:
                UpdateMove(new Vector3(-1, 0, 0), new Vector3(1, 0, 0));
                break;
            case Player.P4:
                UpdateMove(new Vector3(0, 0, -1), new Vector3(0, 0, 1));
                break;
        }
    }

    private void UpdateMove(Vector3 left, Vector3 right)
    {
        if (Input.GetKey(LeftKey))
        {
            Vector3 movement = left * _paddleSpeed;
            Vector3 newPosition = transform.position + movement * Time.deltaTime;
            if (((player == Player.P1 || player == Player.P3) && newPosition.x < gameManager.ArenaMaxSize.x) &&
                ((player == Player.P1 || player == Player.P3) && newPosition.x > gameManager.ArenaMinSize.x) ||
                ((player == Player.P2 || player == Player.P4) && newPosition.z < gameManager.ArenaMaxSize.z) &&
                ((player == Player.P2 || player == Player.P4) && newPosition.z > gameManager.ArenaMinSize.z))
            {
                transform.position = newPosition;
                _rb.velocity = movement;
            }
        }
        if (Input.GetKey(RightKey))
        {
            Vector3 movement = right * _paddleSpeed;
            Vector3 newPosition = transform.position + movement * Time.deltaTime;
            if (((player == Player.P1 || player == Player.P3) && newPosition.x < gameManager.ArenaMaxSize.x) &&
                ((player == Player.P1 || player == Player.P3) && newPosition.x > gameManager.ArenaMinSize.x) ||
                ((player == Player.P2 || player == Player.P4) && newPosition.z < gameManager.ArenaMaxSize.z) &&
                ((player == Player.P2 || player == Player.P4) && newPosition.z > gameManager.ArenaMinSize.z))
            {
                transform.position = newPosition;
                _rb.velocity = movement;
            }
        }
    }

    public void MultiplyPaddleWidthBy(float amount)
    {
        transform.localScale = new Vector3(transform.localScale.x * amount, transform.localScale.y, transform.localScale.z);
    }

    public void DevidePaddleWidthBy(float amount)
    {
        transform.localScale = new Vector3(transform.localScale.x / amount, transform.localScale.y, transform.localScale.z);
    }

    public void MultiplyPaddleSpeedBy(float amount)
    {
        _paddleSpeed *= amount;
    }

    public void DevidePaddleSpeedBy(float amount)
    {
        _paddleSpeed /= amount;
    }

    public void ActivatePaddleSpeedUp(float amount, float lifeTime)
    {
        MultiplyPaddleSpeedBy(amount);
        StartCoroutine(DeactivatePaddleSpeedUP(amount, lifeTime));
    }

    public IEnumerator DeactivatePaddleSpeedUP(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            DevidePaddleSpeedBy(amount);
        }
        catch
        {
            Debug.LogWarning("[PaddleController] Cannot purify power up: Paddle Speed Up, object already destroyed");
        }
    }

    public void ActivatePaddleSlowDown(float amount, float lifeTime)
    {
        DevidePaddleSpeedBy(amount);
        StartCoroutine(DeactivatePaddleSlowDown(amount, lifeTime));
    }

    public IEnumerator DeactivatePaddleSlowDown(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            MultiplyPaddleSpeedBy(amount);
        }
        catch
        {
            Debug.LogWarning("[PaddleController] Cannot purify power up: Paddle Slow Down, object already destroyed");
        }
    }

    public void ActivatePaddleExtend(float amount, float lifeTime)
    {
        MultiplyPaddleWidthBy(amount);
        StartCoroutine(DeactivatePaddleExtend(amount, lifeTime));
    }

    public IEnumerator DeactivatePaddleExtend(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            DevidePaddleWidthBy(amount);
        }
        catch
        {
            Debug.LogWarning("[PaddleController] Cannot purify power up: Paddle Extend, object already destroyed");
        }
    }

    public void ActivatePaddleCollapse(float amount, float lifeTime)
    {
        DevidePaddleWidthBy(amount);
        StartCoroutine(DeactivatePaddleCollapse(amount, lifeTime));
    }

    public IEnumerator DeactivatePaddleCollapse(float amount, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        try
        {
            MultiplyPaddleWidthBy(amount);
        }
        catch
        {
            Debug.LogWarning("[PaddleController] Cannot purify power up: Paddle Collapse, object already destroyed");
        }
    }
}
