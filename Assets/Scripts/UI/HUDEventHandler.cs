using System;
using TMPro;
using UnityEngine;

public class HUDEventHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI stageText;

    public event Action OnButtonActivate;


public void ChangeGold(int amount)
    {
        GameManager.Instance.Gold += amount;
        goldText.text = GameManager.Instance.Gold.ToString();
        OnButtonActivate?.Invoke();
    }

    public void UpdateStageText()
    {
        stageText.text = $"Lv.{ GameManager.Instance.StageNum}";
    }
}