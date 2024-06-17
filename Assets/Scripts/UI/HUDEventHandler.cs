using System;
using TMPro;
using UnityEngine;

public class HUDEventHandler : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI goldText;
    [SerializeField]private TextMeshProUGUI stageText;
    

    public void IncreaseGold(int amount)
    {
        GameManager.Instance.Gold += amount;
        goldText.text = GameManager.Instance.Gold.ToString();
    }

    public void UpdateStageText()
    {
        stageText.text = $"Lv.{ GameManager.Instance.StageNum}";
    }
}