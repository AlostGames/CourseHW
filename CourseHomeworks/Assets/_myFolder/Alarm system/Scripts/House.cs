using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Detector _detector;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        if (_detector != null)
        {
            _detector.RobberEntered += ActivateAlarm;
            _detector.RobberExited += DeactivateAlarm;
        }
    }

    private void OnDisable()
    {
        if (_detector != null)
        {
            _detector.RobberEntered -= ActivateAlarm;
            _detector.RobberExited -= DeactivateAlarm;
        }
    }

    private void ActivateAlarm()
    {
        if (_alarm != null)
        {
            _alarm.On();
        }
    }

    private void DeactivateAlarm()
    {
        if (_alarm != null)
        {
            _alarm.Off();
        }
    }
}
