using System;
using UnityEngine;

public class RestartWindow : Window
{
    private bool _isRestart = false;

    public event Action RestartClicked;

    public void OnGameOver()
    {
        Time.timeScale = 0;
        SetPanelActive(true);
        _isRestart = true;
    }

    public override void OnClick()
    {
        if (_isRestart)
        {
            SetPanelActive(false);
            Time.timeScale = 1;
            RestartClicked?.Invoke();
            _isRestart = false;
        }
    }

    protected override void SetPanelActive(bool isActive)
    {
        base.SetPanelActive(isActive);
        Panel.interactable = isActive;
        Panel.blocksRaycasts = isActive;
    }
}
