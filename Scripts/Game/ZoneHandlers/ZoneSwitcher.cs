using UnityEngine;

public class ZoneSwitcher : MonoBehaviour
{
    [SerializeField] private float _offset = 38.4f;
    [SerializeField] private ZoneController _zoneControllerA;
    [SerializeField] private ZoneController _zoneControllerB;
    [SerializeField] private Vector3 _startPositionA = new Vector3(0, 0, -5);
    [SerializeField] private Vector3 _startPositionB = new Vector3(19.2f, 0, -5);

    private void Start()
    {
        InitializeZones();
    }

    public void SwitchToNext(ZoneController zoneController)
    {
        zoneController.ClearAllObjects();
        zoneController.SetBackgroundPosition(_offset);
        zoneController.SpawnStars();
        zoneController.SpawnEnemies();
    }

    public void ResetZones()
    {
        _zoneControllerA.ResetPosition(_startPositionA);
        _zoneControllerB.ResetPosition(_startPositionB);

        _zoneControllerA.ClearAllObjects();
        _zoneControllerB.ClearAllObjects();

        InitializeZones();
    }

    private void InitializeZones()
    {
        _zoneControllerA.SpawnStars();
        _zoneControllerA.SpawnEnemies();
        _zoneControllerB.SpawnStars();
        _zoneControllerB.SpawnEnemies();
    }
}
