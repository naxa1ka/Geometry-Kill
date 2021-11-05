using System;
using UnityEngine;
using Zenject;

public class MouseInput : IInput, ITickable
{
    public event Action<Vector3> OnClick;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick?.Invoke(Input.mousePosition);
        }
    }

}