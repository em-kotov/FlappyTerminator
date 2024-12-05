public class MetricWindow : Window
{
    private bool _isOpen = false;

    public override void OnClick()
    {
        _isOpen = !_isOpen;
        SetPanelActive(_isOpen);
    }
}
