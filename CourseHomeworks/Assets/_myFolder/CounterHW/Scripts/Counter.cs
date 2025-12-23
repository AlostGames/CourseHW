using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _increaseSpeed = 0.5f;

    private bool _isCounterEnable = false;
    private int _startScore = 0;
    private int _currentScore;
    private Coroutine _coroutine;

    public event Action<int> ScoreChanged;

    public int StartScore => _startScore;

    private void Awake()
    {
        _currentScore = _startScore;
    }

    private void OnEnable()
    {
        _inputReader.MouseButtonDown += ChangeCounterEnable;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonDown -= ChangeCounterEnable;
    }

    private void ChangeCounterEnable()
    {
        if (_isCounterEnable == false)
        {
            _isCounterEnable = true;
            _coroutine = StartCoroutine(CountIncrease(_increaseSpeed));
        }
        else
        {
            _isCounterEnable = false;
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator CountIncrease(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            _currentScore++;
            ScoreChanged?.Invoke(_currentScore);
            yield return wait;
        }
    }
}
