using UnityEngine;
using VContainer;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField] private Transform _gun;
    private GameObject _bullet;   
   private float _bulletSpeed;

    private int bulletCount;
    private GameObject _currentBullet;

    [Inject]
    private void Construct(Settings settings)
    {
        _bullet = settings.bullet;
        _bulletSpeed = settings.bulletSpeed;
    }



    public void Attack()
    {
        _currentBullet = Instantiate(_bullet, _gun.transform.position, Quaternion.identity);


        Rigidbody currentVelocity = _currentBullet.GetComponent<Rigidbody>();
        currentVelocity.linearVelocity = _gun.transform.up * _bulletSpeed;
        bulletCount++;
        Destroy(_currentBullet, 1);
    }
}
