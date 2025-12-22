using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _increaseSpeed = 0.5f;
    [SerializeField] private Color32 _enabledColor = Color.green;
    [SerializeField] private Color32 _disabledColor = Color.red;
    private bool _isCounterEnable = false;
    private int _startScore = 0;
    private int _currentScore;
    private Coroutine _coroutine;

    private void Start()
    {
        _currentScore = _startScore;
        _text.color = _disabledColor;
        _text.text = _startScore.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounterEnable == false)
            {
                _coroutine = StartCoroutine(CountIncrease(_increaseSpeed));
                _text.color = _enabledColor;
                _isCounterEnable = true;
            }
            else
            {
                StopCoroutine(_coroutine);
                _text.color = _disabledColor;
                _isCounterEnable = false;
            }
        }
    }

    private IEnumerator CountIncrease(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _currentScore++;
            DisplayCount();
            yield return wait;
        }
    }

    private void DisplayCount()
    {
        _text.text = _currentScore.ToString();
    }
}
