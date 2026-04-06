using UnityEngine;

public class MoverAroundPlaces : MonoBehaviour
{
    [SerializeField] private Transform _allPlacespoint;
    [SerializeField] private float _speed = 1f;
    private Transform[] _places;
    private int _placeIndex;

    private void Start()
    {
        _places = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
            _places[i] = _allPlacespoint.GetChild(i);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _places[_placeIndex].position,
            _speed * Time.deltaTime);

        if (transform.position == _places[_placeIndex].position)
            ChangePlaceIndex();
    }

    private void ChangePlaceIndex()
    {
        _placeIndex = ++_placeIndex % _places.Length;
    }
}
