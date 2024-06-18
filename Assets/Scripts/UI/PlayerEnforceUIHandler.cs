using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnforceUIHandler : MonoBehaviour
{
    [field:Header("# Enforce Data")]
    [field:SerializeField] public EnforceData[] EnforceDatas { get; private set; }

    [Header("# UI")]
    [SerializeField] private Image statBtnImage;

    

    private void OnEnable()
    {
        GameManager.Instance.StageManager.HUDEventHandler.OnButtonActivate += ActivateButton;
        ActivateButton();
    }

    private void OnDisable()
    {
        GameManager.Instance.StageManager.HUDEventHandler.OnButtonActivate -= ActivateButton;
    }

    public void EnforceStat(int num)
    {
        EnforceData enforce = EnforceDatas[num];
        
        GameManager.Instance.StageManager.HUDEventHandler.ChangeGold(-enforce.requireGold);
        enforce.enforceLevel++;
        
        GameManager.Instance.Player.PlayerStat.EnforceStat(enforce.enforceType, enforce.increasePercent);
        
        enforce.UpdateText();
    }
    
    public void ToggleStatPanel()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        statBtnImage.color = gameObject.activeSelf ? Color.gray : Color.white;
    }

    private void ActivateButton()
    {
        foreach (EnforceData data in EnforceDatas)
        {
            data.UpdateText();
            data.enforceBtn.interactable = data.requireGold <= GameManager.Instance.Gold;
        }
    }

}
