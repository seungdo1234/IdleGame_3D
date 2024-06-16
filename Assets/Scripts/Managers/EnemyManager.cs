using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [field: SerializeField] public List<Transform> enemys { get; private set; } = new List<Transform>();


    private void Start()
    {
        Invoke("dd", 5f);
    }

    private void dd()
    {
        Destroy(enemys[0].gameObject);
        enemys.Clear();
    }
}

