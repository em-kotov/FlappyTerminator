using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpForce = 4f;
    [SerializeField] private float _rotationSpeed = 1f;
    [SerializeField] private float _maxRotationZ = 35f;
    [SerializeField] private float _minRotationZ = -60f;
    [SerializeField] private Vector3 _startPosition = new Vector3(0f, 0f, 0f);

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = _startPosition;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        RotateOverTime();
        // TempMove();
    }

    // private void TempMove()
    // {
    //     // also put constraint on y axis, delete after enemy done
    //     transform.position = Vector2.MoveTowards(transform.position, new Vector2(100, 0),
    //                                             Time.deltaTime * _speed);
    // }

    public void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _jumpForce);
        transform.rotation = _maxRotation;
    }

    public void Reset()
    {
        transform.position = _startPosition;
        Jump();
    }

    private void RotateOverTime()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
                                            _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
