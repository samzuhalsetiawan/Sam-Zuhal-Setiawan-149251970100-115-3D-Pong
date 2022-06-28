using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public List<GameObject> PowerUpList;
    public float PowerUpSpawnInterval;
    public int MaxPowerUpInArena;
    public float PowerUpSpawnDuration;
    public float PowerUpDuration;
    public float PowerUpHeightFromFloor = 0;
    public Transform PowerUpSpawnArea;

    private GameObject _gameManagerObject;
    private GameManager _gameManager;
    private float _timer;
    private readonly List<GameObject> _powerUpSpawnedList = new();
    // Start is called before the first frame update
    void Start()
    {
        _gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = _gameManagerObject.GetComponent<GameManager>();
        _timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= PowerUpSpawnInterval)
        {
            SpawnPowerUp();
            _timer -= PowerUpSpawnInterval;
        }
    }

    private Vector3 GetRandomPowerUpSpawnPosition()
    {
        Vector3 minArenaSize = _gameManager.ArenaMinSize;
        Vector3 maxArenaSize = _gameManager.ArenaMaxSize;
        float randomX = Random.Range(minArenaSize.x, maxArenaSize.x);
        float randomZ = Random.Range(minArenaSize.z, maxArenaSize.z);
        return new Vector3(randomX, PowerUpHeightFromFloor, randomZ);
    }

    public void SpawnPowerUp()
    {
        if (_powerUpSpawnedList.Count >= MaxPowerUpInArena) return;
        GameObject newPowerUp = Instantiate(PowerUpList[Random.Range(0, PowerUpList.Count)], GetRandomPowerUpSpawnPosition(), Quaternion.identity, PowerUpSpawnArea);
        newPowerUp.SetActive(true);
        _powerUpSpawnedList.Add(newPowerUp);
        StartCoroutine(powerUpSpawnExpired());
        IEnumerator powerUpSpawnExpired()
        {
            yield return new WaitForSeconds(PowerUpSpawnDuration);
            try
            {
                RemovePowerUp(newPowerUp);
            }
            catch
            {
                Debug.LogWarning($"[PowerUpManager] Power Up \"{newPowerUp.GetComponent<PowerUp>().Name}\" Already Destroyed");
            }
        }
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        Destroy(powerUp);
        _powerUpSpawnedList.Remove(powerUp);
    }

    public void PowerUpExpireHandler(Collider other, System.Func<GameObject, int> OnPowerUpExpired) 
    {
        StartCoroutine(PowerUpExpired(other, OnPowerUpExpired));
    }

    public IEnumerator PowerUpExpired(Collider other, System.Func<GameObject, int> OnPowerUpExpired)
    {
        yield return new WaitForSeconds(PowerUpDuration);
        try
        {
            OnPowerUpExpired(other.gameObject);
        }
        catch
        {
            Debug.LogWarning("[PowerUpManager] Cannot purify power up, object already destroyed");
        }
    }
}
