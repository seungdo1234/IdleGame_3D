using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field:SerializeField] public Transform StartWaypoint { get; private set; }
    [field:SerializeField] public Transform EndWaypoint { get; private set; }
}
