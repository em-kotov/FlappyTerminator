using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] protected CanvasGroup Panel;

    private void Awake()
    {
        Panel.interactable = false;
        Panel.blocksRaycasts = false;
        SetPanelActive(false);
    }

    public virtual void OnClick() { }

    protected virtual void SetPanelActive(bool isActive)
    {
        int panelAlphaVisible = 1;
        int panelAlphaTransparent = 0;

        Panel.alpha = isActive ? panelAlphaVisible : panelAlphaTransparent;
    }
}
