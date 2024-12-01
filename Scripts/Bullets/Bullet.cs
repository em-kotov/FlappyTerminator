using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;

    public Vector2 EndPosition { get; protected set; }
    public Vector2 StartPosition { get; protected set; }
    public Coroutine MoveCoroutine { get; protected set; }

    public void SetEndPosition(Vector2 endPosition)
    {
        EndPosition = endPosition;
    }
    
    public void SetStartPosition(Vector2 startPosition)
    {
        StartPosition = startPosition;
    }
    
    public void SetMoveCoroutine(Coroutine moveCoroutine)
    {
        MoveCoroutine = moveCoroutine;
    }

    public void ResetMoveCoroutine()
    {
        MoveCoroutine = null;
    }
}