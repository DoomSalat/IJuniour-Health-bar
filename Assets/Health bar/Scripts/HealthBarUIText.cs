using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarUIText : HealthBar
{
	private TextMeshProUGUI _textUI;
	private float _maxValue = 100;
	private float _currentValue = 100;

	private float CurrentValue
	{
		get { return _currentValue; }
		set { _currentValue = Mathf.Clamp(value, 0, _maxValue); }
	}

	private void Awake()
	{
		_textUI = GetComponent<TextMeshProUGUI>();
	}

	protected override void Initializate(float value)
	{
		_maxValue = value;
		_currentValue = value;
	}

	protected override void Change(float value)
	{
		CurrentValue += value;

		_textUI.text = $"{CurrentValue}/{_maxValue}";
	}
}
