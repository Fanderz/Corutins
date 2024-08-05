using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _counterText;

    private void Start()
    {
        _counterText.text = _counter.CurrentNumber.ToString();
    }

    private void OnEnable()
    {
        _counter.Changed += DisplayNumber;
    }

    private void OnDisable()
    {
        _counter.Changed -= DisplayNumber;
    }

    private void DisplayNumber(float number)
    {
        _counterText.text = number.ToString();
    }
}
