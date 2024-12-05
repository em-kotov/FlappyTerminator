using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode ShootKey = KeyCode.Space;
    private const KeyCode MetricKey = KeyCode.R;

    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;
    public event Action MetricKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed?.Invoke();

        if (Input.GetKeyDown(ShootKey))
            ShootKeyPressed?.Invoke();

        if (Input.GetKeyDown(MetricKey))
            MetricKeyPressed?.Invoke();
    }
}
