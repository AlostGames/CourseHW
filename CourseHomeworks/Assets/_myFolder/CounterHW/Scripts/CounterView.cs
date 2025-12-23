using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _counter.StartScore.ToString();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= DisplayCount;
    }

    private void DisplayCount(int score)
    {
        _text.text = score.ToString();
    }
}
