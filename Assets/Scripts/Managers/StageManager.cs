using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("# Stage Info")]
    [SerializeField] private int spawnEnemyNum;
    [SerializeField] private int enemyLevelEvent;
    
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
            currentWaypointIndex = (currentWaypointIndex + 1) % EndWayPoints.Length; 
            return waypoint;
        } 
    }
    
    [Header("# Stage Effect")]
    [SerializeField] private BackgroundEventHandler backgroundEventHandler;
    [SerializeField] private float stageFadeDuration = 2f;

    [field:Header("# HUD")]
    [field:SerializeField] public HUDEventHandler HUDEventHandler { get; private set; }
        
    private Coroutine newStageCoroutine;
    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(stageFadeDuration + 0.2f);
    }

    private IEnumerator Start()
    {
        // TODO : Player Start함수 순서보다 빨라서 일단 임시로 조치해놓음. 추후에 수정할 예정
        yield return null;
        StageInit();
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
        StageInit();
        StageLevelEvent();
        backgroundEventHandler.FadeTo(0f, stageFadeDuration);
        HUDEventHandler.UpdateStageText();
    }

    private void StageInit()
    {
        EnemyManager.Instance.SpawnEnemy(spawnEnemyNum);
        GameManager.Instance.Player.StartNewStage();
    }

    private void StageLevelEvent()
    {
        int stageNum = ++GameManager.Instance.StageNum;
        if (stageNum % enemyLevelEvent == 0 && EnemyManager.Instance.SpawnPoints.Length > spawnEnemyNum )
        {
            spawnEnemyNum++;
        }
    }
}