using UnityEngine;

public class ClickChecker : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private void OnMouseDown()
    {
        _cube.Activate();
    }
}
