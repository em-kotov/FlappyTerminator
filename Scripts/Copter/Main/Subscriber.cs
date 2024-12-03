using UnityEngine;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private CollisionRegister _collisionRegister;
    [SerializeField] private Mover _mover;
    [SerializeField] private PlayerShoot _shoot;
    [SerializeField] private Copter _copter;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryDisplay _inventoryDisplay;
    [SerializeField] private ZoneSwitcher _zoneSwitcher;
    [SerializeField] private RestartWindow _restartWindow;

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += _mover.Jump;
        _inputReader.JumpKeyPressed += _restartWindow.OnRestarButtonClick;
        _inputReader.ShootKeyPressed += _shoot.FireBullet;

        _collisionRegister.GroundFound += _copter.OnObstacleFound;
        _collisionRegister.EnemyFound += _copter.OnObstacleFound;
        _collisionRegister.BulletFound += _copter.OnObstacleFound;

        _collisionRegister.StarFound += _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound += _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged += _inventoryDisplay.DisplayStarCount;

        _copter.GameOver += _restartWindow.OnGameOver;

        _restartWindow.RestartClicked += _inventory.Reset;
        _restartWindow.RestartClicked += _mover.Reset;
        _restartWindow.RestartClicked += _shoot.DestroyAllBullets;
        _restartWindow.RestartClicked += _zoneSwitcher.ResetZones;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= _mover.Jump;
        _inputReader.JumpKeyPressed -= _restartWindow.OnRestarButtonClick;
        _inputReader.ShootKeyPressed -= _shoot.FireBullet;

        _collisionRegister.GroundFound -= _copter.OnObstacleFound;
        _collisionRegister.EnemyFound -= _copter.OnObstacleFound;
        _collisionRegister.BulletFound -= _copter.OnObstacleFound;

        _collisionRegister.StarFound -= _inventory.AddStar;
        _collisionRegister.NextZoneControllerFound -= _zoneSwitcher.SwitchToNext;

        _inventory.StarCountChanged -= _inventoryDisplay.DisplayStarCount;

        _copter.GameOver -= _restartWindow.OnGameOver;

        _restartWindow.RestartClicked -= _inventory.Reset;
        _restartWindow.RestartClicked -= _mover.Reset;
        _restartWindow.RestartClicked -= _shoot.DestroyAllBullets;
        _restartWindow.RestartClicked -= _zoneSwitcher.ResetZones;
    }
}
