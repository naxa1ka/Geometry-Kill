using UnityEngine;

public class TimeState
{
    public void Stop()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}