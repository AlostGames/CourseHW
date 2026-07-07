using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource alarmSource;
    [SerializeField] private float _fadeSpeed = 0.5f;

    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;
    private float _targetVolume = 0.0f;

    private void Update()
    {
        if (_targetVolume != alarmSource.volume)
        {
            alarmSource.volume = Mathf.MoveTowards(alarmSource.volume, 
                _targetVolume, _fadeSpeed * Time.deltaTime);

            if (_targetVolume == alarmSource.volume && _targetVolume == 0)
            {
                alarmSource.Stop();
            }
        }
    }

    public void On()
    {
        _targetVolume = _maxVolume;
        alarmSource.Play();
    }

    public void Off()
    {
        _targetVolume = _minVolume;
    }
}
