using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("# Stage")]
    [SerializeField] private BackgroundEventHandler backgroundEventHandler;
    [SerializeField] private float stageFadeDuration = 2f;

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

    }
}
