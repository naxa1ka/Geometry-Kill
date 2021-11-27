using System;

public interface IHealth
{
    public event Action<int, int> OnHealthChanged;
}