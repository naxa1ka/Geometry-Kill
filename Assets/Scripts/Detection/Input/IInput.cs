using System;
using UnityEngine;

public interface IInput
{
    public event Action<Vector3> OnClick;
}