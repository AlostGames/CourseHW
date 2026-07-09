using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public event Action RobberEntered;
    public event Action RobberExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RobberMover>())
        {
            RobberEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RobberMover>())
        {
            RobberExited?.Invoke();
        }
    }
}
