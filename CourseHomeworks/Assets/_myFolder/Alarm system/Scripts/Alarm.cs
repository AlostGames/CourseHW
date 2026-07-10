using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSource;
    [SerializeField] private float _fadeSpeed = 0.5f;

    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;
    private Coroutine _volumeCoroutine;

    public void On()
    {
        _alarmSource.Play();
        ChangeVolume(_maxVolume);
    }

    public void Off()
    {
        ChangeVolume(_minVolume);
    }

    private void ChangeVolume(float targetVolume)
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(FadeVolume(targetVolume));
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        while (targetVolume != _alarmSource.volume)
        {
            _alarmSource.volume = Mathf.MoveTowards(_alarmSource.volume,
                targetVolume, _fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_alarmSource.volume == 0)
        {
            _alarmSource.Stop();
        }

        _volumeCoroutine = null;
    }
}
