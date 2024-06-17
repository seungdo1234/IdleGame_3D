using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
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
                StartNewStage();
            Transform waypoint = EndWayPoints[currentWaypointIndex];
            currentWaypointIndex = (currentWaypointIndex + 1) % EndWayPoints.Length; // 인덱스를 증가시키고 배열 길이로 모듈러 연산
            return waypoint;
        } 
    }
    
    [Header("# Stage Effect")]
    [SerializeField] private BackgroundEventHandler backgroundEventHandler;
    [SerializeField] private float stageFadeDuration = 2f;

    [field:Header("# Gold")]
    [field:SerializeField] public HUDEventHandler HUDEventHandler { get; private set; }
        
    private Coroutine newStageCoroutine;
    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(stageFadeDuration + 0.2f);
    }

    public void StartNewStage()
    {
        if (newStageCoroutine != null)
        {
            StopCoroutine(newStageCoroutine);
        }

        newStageCoroutine = StartCoroutine(NewStageCoroutine());

    }

    private IEnumerator NewStageCoroutine()
    {
        backgroundEventHandler.FadeTo(1f, stageFadeDuration);
        yield return wait;
        EnemyManager.Instance.SpawnEnemy();
        GameManager.Instance.Player.StartNewStage();
        backgroundEventHandler.FadeTo(0f, stageFadeDuration);
        GameManager.Instance.StageNum++;
        HUDEventHandler.UpdateStageText();
    }
}