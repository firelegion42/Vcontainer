using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour
{
    protected float _maxHealth;
    protected float _currentHealth;
    protected bool _dead;

    public float CurrentHealth => _currentHealth;
    public bool Dead => _dead;

    public float HealthPercent => _currentHealth / _maxHealth;

    [SerializeField] public UnityEvent<float> healthChanged;
    [SerializeField] public UnityEvent death;


    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        Debug.Log(_currentHealth);
        healthChanged.Invoke(CurrentHealth);
        if (_currentHealth <= 0)
        {
            _dead = true;
            death.Invoke();
            Death();
        }
    }

    public abstract void Death();
 
}
