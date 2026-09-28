using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))           
        {
            damageable.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
