using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private float _currentNumber = 0f;
    [SerializeField] private float _delay = 0.5f;

    private bool _isRunning = false;

    private Coroutine _coroutine;

    public float CurrentNumber => _currentNumber;

    public event Action<float> Changed;

    private void Start()
    {
        _button.onClick.AddListener(Enable);
    }

    private void Enable()
    {
        _isRunning = true;
        _button.onClick.RemoveListener(Enable);
        _button.onClick.AddListener(Disable);
        _coroutine = StartCoroutine(IncreaseNumber());
    }

    private void Disable()
    {
        _isRunning = false;
        _button.onClick.RemoveListener(Disable);
        _button.onClick.AddListener(Enable);

        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator IncreaseNumber()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isRunning)
        {
            Changed?.Invoke(++_currentNumber);

            yield return wait;
        }
    }
}
