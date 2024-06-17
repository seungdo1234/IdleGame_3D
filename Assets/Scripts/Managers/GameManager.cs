using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{

    [field:Header("# ObjectPool")]
    [field:SerializeField] public PoolManager Pool { get; private set; }
    
    [field:Header("# Stage Info")]
    [field:SerializeField] public StageManager StageManager { get; private set; }
    public Player Player { get; set; }
    
    [field:Header("# Player Data")]
    [field:SerializeField] public int Gold { get; set; }
    [field:SerializeField] public int StageNum { get; set; }
    
    
}
