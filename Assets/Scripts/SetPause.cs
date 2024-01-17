using UnityEngine;

public class SetPause : MonoBehaviour
{
    private bool _isPaused = false;

    public void SetTime()
    {
        Time.timeScale = _isPaused ? 1.0f : 0.0f;
        _isPaused = !_isPaused;
    }
}
