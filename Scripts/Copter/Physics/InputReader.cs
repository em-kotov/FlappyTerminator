using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode ShootKey = KeyCode.Space;

    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed?.Invoke();

        if (Input.GetKeyDown(ShootKey))
            ShootKeyPressed?.Invoke();
    }
}
