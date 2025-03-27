using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] private int _maxHealth = 100;

	private int _currentHealth;

	public event System.Action<float, float> Changed;

	public int CurrentHealth
	{
		get => _currentHealth;
		set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
	}

	private void Awake()
	{
		_currentHealth = _maxHealth;
	}

	public void TakeDamage(int damage)
	{
		damage = Mathf.Max(0, damage);
		CurrentHealth -= damage;

		Changed?.Invoke(CurrentHealth, _maxHealth);
	}

	public void Heal(int health)
	{
		health = Mathf.Max(0, health);
		CurrentHealth += health;

		Changed?.Invoke(CurrentHealth, _maxHealth);
	}
}
