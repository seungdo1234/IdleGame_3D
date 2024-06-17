using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [field:Header("# Stage WayPoint Info")]
    [field:SerializeField] public Transform StartWaypoint { get; private set; }
    [SerializeField] private Transform[] EndWayPoints;
    private int currentWaypointIndex = 0; // 현재 인덱스를 추적하는 변수
    public Transform GetEndWaypoint
    {
        get
        {
            if(currentWaypointIndex == 1)
                stageManager.StartNewStage();
            Transform waypoint = EndWayPoints[currentWaypointIndex];
            currentWaypointIndex = (currentWaypointIndex + 1) % EndWayPoints.Length; // 인덱스를 증가시키고 배열 길이로 모듈러 연산
            return waypoint;
        } 
    }

    [field:Header("# ObjectPool")]
    [field:SerializeField] public PoolManager Pool { get; private set; }


    [Header("# Stage Info")]
    [SerializeField] private StageManager stageManager;
    public Player Player { get; set; }

}