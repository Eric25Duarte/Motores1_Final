
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPlayer : MonoBehaviour
{
    public Player Player;
    public Tower Tower;

    // Usando dicionários para lookup
    public Dictionary<EnemyType, GameObject> EnemyPrefabsDict = new Dictionary<EnemyType, GameObject>();
    public Dictionary<string, GameObject> PowerUpPrefabsDict = new Dictionary<string, GameObject>();

    public GameObject[] EnemyPrefabs;
    public GameObject[] PowerUpPrefabs;

    public Transform[] SpawnPoints;
    public float EnemySpawnInterval = 5f;
    public float PowerUpSpawnInterval = 10f;

    private void Start()
    {
        // Inicializa dicionários
        EnemyPrefabsDict[EnemyType.Blade] = EnemyPrefabs[0];
        EnemyPrefabsDict[EnemyType.Shooter] = EnemyPrefabs[1];
        EnemyPrefabsDict[EnemyType.Explosive] = EnemyPrefabs[2];
        PowerUpPrefabsDict["Heal"] = PowerUpPrefabs[0];
        PowerUpPrefabsDict["Shield"] = PowerUpPrefabs[1];

        GameEventManager.OnGameOver += EndGame;
        InvokeRepeating(nameof(SpawnEnemy), 0f, EnemySpawnInterval);
        InvokeRepeating(nameof(SpawnPowerUp), 0f, PowerUpSpawnInterval);
    }

    private void SpawnEnemy()
    {
        // Exemplo usando Enum
        EnemyType type = (EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
        int spawnIndex = UnityEngine.Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefabsDict[type], SpawnPoints[spawnIndex].position, Quaternion.identity);
    }

    private void SpawnPowerUp()
    {
        // Exemplo usando chave string
        string[] keys = new List<string>(PowerUpPrefabsDict.Keys).ToArray();
        string key = keys[UnityEngine.Random.Range(0, keys.Length)];
        int spawnIndex = UnityEngine.Random.Range(0, SpawnPoints.Length);
        Instantiate(PowerUpPrefabsDict[key], SpawnPoints[spawnIndex].position, Quaternion.identity);
    }

    private void EndGame()
    {
        Debug.Log("Game Over!");
        CancelInvoke();
    }

    private void OnEnable()
    {
        GameEventManager.OnGameOver += HandleGameOver;
        Player.OnPlayerDeath += EndGame;
        Enemy.OnEnemyDeath += OnEnemyKilled;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameOver -= HandleGameOver;
        Player.OnPlayerDeath -= EndGame;
        Enemy.OnEnemyDeath -= OnEnemyKilled;
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over triggered from GameEventManager.");
        // Add logic to stop the game or display a game-over screen.
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        Debug.Log($"Enemy killed: {enemy.Type}");
        // Exemplo: adicionar pontuação, spawnar algo, etc.
    }
}
