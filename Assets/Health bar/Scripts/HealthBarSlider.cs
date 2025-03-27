using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSlider : HealthBar
{
	private Slider _slider;

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	protected override void Initializate(float value)
	{
		_slider.maxValue = value;
		_slider.value = value;
	}

	protected override void Change(float value)
	{
		_slider.value += value;
	}
}
