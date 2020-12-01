using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject startingWaypoint;
    public static ShipSpawner instance;
    int maxPlayer;
    int maxEnemy1;
    int maxEnemy2;
    int maxEnemy3;
    public float playerSpawnTimer;
    public float enemy1SpawnTimer;
    public float enemy2SpawnTimer;
    public static int currentPlayerSpawned;
    public static int currentEnemy1Spawned;
    public static int currentEnemy2Spawned;
    public static int currentEnemy3Spawned;
    Vector2 newLocation;
    public List<GameObject> enemy3List = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        maxPlayer = 1;
        maxEnemy1 = 1;
        maxEnemy2 = 5;
        maxEnemy3 = 3;
        currentPlayerSpawned = 1;
    }
    void Update()
    {
        if (currentPlayerSpawned < maxPlayer)
        {
            SpawnPlayer();
        }
        if (currentEnemy1Spawned < maxEnemy1)
        {
            SpawnEnemy1();
        }
        if (currentEnemy2Spawned < maxEnemy2)
        {
            SpawnEnemy2();
        }
    }

    void SpawnPlayer()
    {
        playerSpawnTimer -= Time.deltaTime;
        if (playerSpawnTimer < 0)
        {
            Instantiate(playerPrefab, transform.position, transform.rotation);
            currentPlayerSpawned++;
            playerSpawnTimer = 5;
        }
    }
    void SpawnEnemy1()
    {
        enemy1SpawnTimer -= Time.deltaTime;
        if (enemy1SpawnTimer < 0)
        {
            Instantiate(enemy1Prefab, startingWaypoint.transform.position, startingWaypoint.transform.rotation);
            currentEnemy1Spawned++;
            enemy1SpawnTimer = 10;
        }
    }
    void SpawnEnemy2()
    {
        enemy2SpawnTimer -= Time.deltaTime;
        if (enemy2SpawnTimer < 0)
        {
            newLocation = new Vector2(Random.Range(-8, 8), Random.Range(-1, 4.5f));
            Instantiate(enemy2Prefab, newLocation, Quaternion.Euler(0, 0, 0));
            currentEnemy2Spawned++;
            enemy2SpawnTimer = 15;
        }
    }
    public void SpawnEnemy3(Transform playerObj)
    {
        
        if (currentEnemy3Spawned < maxEnemy3)
        {
            GameObject newEnemy3 = Instantiate(enemy3Prefab, playerObj.transform.position, playerObj.transform.rotation);            
            currentEnemy3Spawned++;
            enemy3List.Add(newEnemy3);
        }
        else if (currentEnemy3Spawned >= maxEnemy3)
        {
            GameObject enemyToRemove = enemy3List[0];
            enemy3List.Remove(enemyToRemove);
            Destroy(enemyToRemove);
            GameObject newEnemy3 = Instantiate(enemy3Prefab, playerObj.transform.position, playerObj.transform.rotation);
            currentEnemy3Spawned++;
            enemy3List.Add(newEnemy3);
        }
    }
}
