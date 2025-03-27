using System;
using UnityEngine;

public class HealthChanger : MonoBehaviour
{
	[SerializeField][Min(0)] private float _maxHealth = 100;

	public event Action<float> Changed;
	public event Action<float> InitializateMax;

	private void Start()
	{
		InitializateMax?.Invoke(_maxHealth);
	}

	public void Change(float value)
	{
		Changed?.Invoke(value);
	}
}
