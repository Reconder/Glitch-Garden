
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;
    [SerializeField] float minSpawnPeriod = 9f;
    [SerializeField] float maxSpawnPeriod = 16f;
    [SerializeField] Attacker[] enemyPrefabs;
    [SerializeField] LevelController levelController;
    [SerializeField] bool random = true;
    

    void Awake()
    {
        levelController.OnGameStop += StopSpawning;
        levelController.IncreaseDifficulty += IncreaseDifficulty;
        if (random) { AdjustDifficulty(); }
    }

    private void IncreaseDifficulty()
    {
        if (minSpawnPeriod > 1)
        {
            minSpawnPeriod--;
            maxSpawnPeriod--;
        }
    }


    IEnumerator Start()
    {
        
        
        while (spawn)
        {
            if (random) yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnPeriod, maxSpawnPeriod));
            SpawnEnemy();
        } 
    }


    private void AdjustDifficulty()
    {
        minSpawnPeriod -= ((minSpawnPeriod-6)/10) * PlayerPrefsController.MasterDifficulty;
        maxSpawnPeriod -= ((maxSpawnPeriod - 9) / 10) * PlayerPrefsController.MasterDifficulty;
    }

    public void StopSpawning() => spawn = false;

    private void SpawnEnemy()
    {
        int i = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        Spawn(enemyPrefabs[i]);
    }

    private void Spawn(Attacker enemy)
    {
        Attacker newEnemy = Instantiate(enemy, transform.position, Quaternion.identity) as Attacker;
        newEnemy.transform.parent = transform;
        newEnemy.OnAttackerSpawned += levelController.OnAttackerSpawn;
        newEnemy.OnAttackerDestroyed += levelController.OnAttackerDestroyed;

    }
}
