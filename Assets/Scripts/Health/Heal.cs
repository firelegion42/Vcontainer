using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private float _healingAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IHealable>(out var healable))
        {
            healable.Heal(_healingAmount);
            Destroy(gameObject);
        }
    }
}
