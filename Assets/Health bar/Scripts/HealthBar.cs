using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
	[SerializeField] private HealthChanger _healthChanger;

	private void OnEnable()
	{
		_healthChanger.InitializateMax += Initializate;
		_healthChanger.Changed += Change;
	}

	private void OnDisable()
	{
		_healthChanger.InitializateMax -= Initializate;
		_healthChanger.Changed -= Change;
	}

	protected abstract void Initializate(float value);
	protected abstract void Change(float value);
}
