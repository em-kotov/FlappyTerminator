using UnityEngine;

public class Bullet : Collectible<Bullet>, IInteractable
{
    public Vector2 EndPosition { get; protected set; }
    public Vector2 StartPosition { get; protected set; }
    public Coroutine MoveCoroutine { get; protected set; }

    public void Initialize(Vector2 startPosition, Vector2 endPosition)
    {
        SetCollectibleItem(this);
        StartPosition = startPosition;
        EndPosition = endPosition;
    }

    public void SaveCoroutine(Coroutine moveCoroutine)
    {
        MoveCoroutine = moveCoroutine;
    }

    public override void Deactivate()
    {
        if (MoveCoroutine != null)
        {
            StopCoroutine(MoveCoroutine);
            MoveCoroutine = null;
        }

        base.Deactivate();
    }
}