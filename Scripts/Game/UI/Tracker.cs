using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Copter _copter;
    [SerializeField] private float _offsetX = 1f;

    private void Update()
    {
        Vector3 position = transform.position;
        position.x = _copter.transform.position.x + _offsetX;
        transform.position = position;
    }
}
