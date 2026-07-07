using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter(Collider robber)
    {
        _alarm.On();
    }

    private void OnTriggerExit(Collider robber)
    {
        _alarm.Off();
    }
}
