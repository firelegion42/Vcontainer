using UnityEngine;
using VContainer;

public class EnemyHealth : Health, IDamageable
{
    [Inject]
    private void Construct(Settings settings)
    {
        _maxHealth = settings.enemyMaxHealth;
        _currentHealth = _maxHealth;
    }
    public override void Death()
    {
        Debug.Log(_currentHealth);
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
