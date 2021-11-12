using System;
using UnityEngine;
using Zenject;

public class MouseInput : IInput, ITickable
{
    public event Action<Vector3> OnClick;
    private const int LeftMouseButton = 0;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnClick?.Invoke(Input.mousePosition);
        }
    }

}