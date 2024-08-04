using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;
    [SerializeField] private float _minNumber = 0f;
    [SerializeField] private float _maxNumber = 100f;
    [SerializeField] private float _delay = 0.5f;

    private bool _isRunning = false;

    private void Start()
    {
        _text.text = _minNumber.ToString();
        _button.onClick.AddListener(Enable);
    }

    private void Enable()
    {
        _isRunning = true;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(Disable);
        StartCoroutine(IncreaseNumber());
    }

    private void Disable()
    {
        _isRunning = false;
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(Enable);
        StopCoroutine(IncreaseNumber());
    }

    private IEnumerator IncreaseNumber()
    {
        var wait = new WaitForSeconds(_delay);

        while (_minNumber < _maxNumber && _isRunning)
        {
            DisplayNumber(_minNumber++);

            yield return wait;
        }
    }

    private void DisplayNumber(float number)
    {
        _text.text = number.ToString();
    }
}
