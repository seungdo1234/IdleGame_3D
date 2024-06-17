using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject statPanel;

    public void ToggleStatPanel()
    {
        statPanel.SetActive(!statPanel.activeSelf);
    }
    
    
}