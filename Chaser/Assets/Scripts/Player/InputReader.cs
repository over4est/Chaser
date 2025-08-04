using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    public event Action<Vector3> MoveNeeded;

    private void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0f, Input.GetAxis(Vertical));

        if (direction == Vector3.zero)
            return;

        MoveNeeded?.Invoke(direction);
    }
}