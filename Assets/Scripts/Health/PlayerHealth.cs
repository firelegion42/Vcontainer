using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class PlayerHealth : Health, IDamageable, IHealable
{
    [Inject]   
    private void Construct(Settings settings)
    {
        _maxHealth = settings.playerMaxHealth;
        _currentHealth = _maxHealth;
    }
    

    public void Heal(float healingAmount)
    {
        _currentHealth += healingAmount;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        Debug.Log(_currentHealth);
    }

    public override void Death()
    {
        Debug.Log(_currentHealth);
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
