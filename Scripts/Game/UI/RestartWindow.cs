using System;
using UnityEngine;

public class RestartWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _restartPanel;

    private bool _isRestart = false;

    public event Action RestartClicked;

    private void Awake()
    {
        SetPanelActive(false);
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        SetPanelActive(true);
        _isRestart = true;
    }

    public void OnRestarButtonClick()
    {
        if (_isRestart)
        {
            SetPanelActive(false);
            Time.timeScale = 1;
            RestartClicked?.Invoke();
            _isRestart = false;
        }
    }

    private void SetPanelActive(bool isActive)
    {
        int panelAlphaVisible = 1;
        int panelAlphaTransparent = 0;

        _restartPanel.alpha = isActive ? panelAlphaVisible : panelAlphaTransparent;
        _restartPanel.interactable = isActive;
        _restartPanel.blocksRaycasts = isActive;
    }
}
