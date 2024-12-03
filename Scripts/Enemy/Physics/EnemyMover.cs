using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.3f;
    [SerializeField] private Vector3 _startPosition = new Vector3(10f, 0f, 0f);
    [SerializeField] private Vector3 _endPosition = new Vector3(-10f, 0f, 0f);

    private void Update()
    {
        Move();
    }

    public void Initialize(Vector3 startPosition, Vector3 endPosition)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _endPosition, 
                                                Time.deltaTime * _speed);
    }
}
