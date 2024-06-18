using System;
using TMPro;
using UnityEngine.UI;

public enum EnforceType{Attack, Speed, AttackDelay, CriticalPercent, CriticalDamage }

[Serializable]
public class EnforceData
{
    public EnforceType enforceType;
    public int enforceLevel = 1;
    public int requireGold= 2;
    public float increasePercent = 0.01f;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI goldText;
    public Button enforceBtn;
    
    public void UpdateText()
    {
        goldText.text = requireGold.ToString();
        titleText.text = $"{GetEnforceType()} Lv.{enforceLevel}";
    }

    public string GetEnforceType()
    {
        string text = enforceType switch
        {
            EnforceType.Attack => "공격력",
            EnforceType.Speed => "스피드",
            EnforceType.AttackDelay => "공격속도",
            EnforceType.CriticalPercent => "치명타 확률",
            EnforceType.CriticalDamage => "치명타 데미지",
            _ => "이름을 설정해주세요."
        };
        
        return text;
    }
}