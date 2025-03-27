using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class HealthBarSmoothSlider : HealthBar
{
	[SerializeField][Min(0)] private float _smoothSpeed = 5f;
	private float _realValue;

	private Slider _slider;
	private Coroutine _smoothChangeCoroutine;

	private float RealValue
	{
		get { return _realValue; }
		set { _realValue = Mathf.Clamp(value, 0, _slider.maxValue); }
	}

	private void Awake()
	{
		_slider = GetComponent<Slider>();
	}

	protected override void Initializate(float value)
	{
		_slider.maxValue = value;
		_slider.value = value;
		RealValue = value;
	}

	protected override void Change(float value)
	{
		RealValue += value;

		if (_smoothChangeCoroutine != null)
		{
			StopCoroutine(_smoothChangeCoroutine);
		}

		_smoothChangeCoroutine = StartCoroutine(SmoothUpdate(RealValue));
	}

	private IEnumerator SmoothUpdate(float targetValue)
	{
		float startValue = _slider.value;
		float progress = 0f;

		while (progress < 1f)
		{
			progress += Time.deltaTime * _smoothSpeed;
			_slider.value = Mathf.Lerp(startValue, targetValue, progress);

			yield return null;
		}

		_slider.value = targetValue;
		_smoothChangeCoroutine = null;
	}
}
