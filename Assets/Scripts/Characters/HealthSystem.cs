using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public CharacterStat Stat { get; set; } 
    
    public void HealthEvent(float amount)
    {
        Debug.Log(amount);
        Stat.CurHealth += amount;
        Stat.CurHealth = Mathf.Clamp(Stat.CurHealth, 0, Stat.MaxHealth);

        if (Stat.CurHealth <= 0)
        {
            Debug.Log("죽었다");
            // TODO : 임시로 Enemy만 사라지게 작업함. 추후에 Player와 Enemy 나눌 예정
            gameObject.SetActive(false);
            EnemyManager.Instance.EnemyDie(gameObject);
        }
    }
}
