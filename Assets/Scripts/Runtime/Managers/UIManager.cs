using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel, failPanel;

    private void Awake()
    {
        GameEvents.OnWin += OpenWinPanel;
        GameEvents.OnFail += OpenFailPanel;
    }

    private void OnDestroy()
    {
        GameEvents.OnWin -= OpenWinPanel;
        GameEvents.OnFail -= OpenFailPanel;
    }

    private void OpenWinPanel()
    {
        winPanel.SetActive(true);
    }

    private void OpenFailPanel()
    {
        failPanel.SetActive(true);
    }
}