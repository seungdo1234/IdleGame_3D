using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class EnemyManager : Singleton<EnemyManager>
{
    [field: Header("# Enemy Info")]
    [SerializeField] private EnemySO enemySO;

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
            enemy.Init(enemySO);

            while (true)
            {
                int rand = Random.Range(0, SpawnPoints.Length);

                if (!SpawnEnemyList.Find(obj => SpawnPoints[rand].position == obj.transform.position))
                {
                    SetEnemyPosition(enemy, rand);
                    SpawnEnemyList.Add(enemy);
                    break;
                }
            }
        }
    }

    private void SetEnemyPosition(Enemy enemy, int rand) // 캐릭터 컨트롤러 이슈로 인한 함수
    {
        enemy.Controller.enabled = false;
        enemy.transform.position = SpawnPoints[rand].position;
        enemy.Controller.enabled = true;
    }

}

