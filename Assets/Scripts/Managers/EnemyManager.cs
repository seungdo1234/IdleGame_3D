using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class EnemyManager : Singleton<EnemyManager>
{
    [field:Header("# Enemy Info")]
    [field: SerializeField] public List<Enemy> SpawnEnemyList { get; private set; } = new List<Enemy>();

    [field: Header("# Enemy Spawn Info")]
    [SerializeField] private int enemySpawnNum = 3;
    [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
    
    
    public void EnemyDie(GameObject enemy)
    {
        SpawnEnemyList.Remove(SpawnEnemyList.Find(obj => enemy == obj.gameObject));
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        SpawnEnemyList.Clear();

        for (int i = 0; i < enemySpawnNum; i++)
        {
            Enemy enemy = GameManager.Instance.Pool.SpawnFromPool(EPoolObjectType.Enemy).ReturnMyConponent<Enemy>();

            while (true)
            {
                int rand = Random.Range(0, SpawnPoints.Length);

                if (!SpawnEnemyList.Find(obj => SpawnPoints[rand].position == obj.transform.position))
                {
                    enemy.transform.position = SpawnPoints[rand].position;
                    SpawnEnemyList.Add(enemy);
                    break;
                }
            }
        }
    }
}

