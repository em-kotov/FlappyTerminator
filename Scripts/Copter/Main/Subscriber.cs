using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CollisionRegister _collisionRegister;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerShoot _shoot;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryDisplay _inventoryDisplay;
    [SerializeField] private ZoneSwitcher _zoneSwitcher;
    [SerializeField] private RestartWindow _restartWindow;
    [SerializeField] private MetricWindow _metricWindow;

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += _mover.Jump;
        _inputReader.JumpKeyPressed += _restartWindow.OnClick;
        _inputReader.ShootKeyPressed += _shoot.FireBullet;
        _inputReader.MetricKeyPressed += _metricWindow.OnClick;

        _collisionRegister.GroundFound += _restartWindow.OnGameOver;
        _collisionRegister.EnemyFound += _restartWindow.OnGameOver;
        _collisionRegister.BulletFound += _restartWindow.OnGameOver;

        _collisionRegister.StarFound += _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound += _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged += _inventoryDisplay.DisplayStarCount;

        _restartWindow.RestartClicked += _inventory.Reset;
        _restartWindow.RestartClicked += _mover.Reset;
        _restartWindow.RestartClicked += _shoot.DestroyAllObjects;
        _restartWindow.RestartClicked += _zoneSwitcher.ResetZones;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= _mover.Jump;
        _inputReader.JumpKeyPressed -= _restartWindow.OnClick;
        _inputReader.ShootKeyPressed -= _shoot.FireBullet;
        _inputReader.MetricKeyPressed -= _metricWindow.OnClick;

        _collisionRegister.GroundFound -= _restartWindow.OnGameOver;
        _collisionRegister.EnemyFound -= _restartWindow.OnGameOver;
        _collisionRegister.BulletFound -= _restartWindow.OnGameOver;

        _collisionRegister.StarFound -= _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound -= _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged -= _inventoryDisplay.DisplayStarCount;

        _restartWindow.RestartClicked -= _inventory.Reset;
        _restartWindow.RestartClicked -= _mover.Reset;
        _restartWindow.RestartClicked -= _shoot.DestroyAllObjects;
        _restartWindow.RestartClicked -= _zoneSwitcher.ResetZones;
    }
}
