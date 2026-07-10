using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public event Action RobberEntered;
    public event Action RobberExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RobberMover>(out RobberMover robberMover))
        {
            RobberEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<RobberMover>(out RobberMover robberMover))
        {
            RobberExited?.Invoke();
        }
    }
}
