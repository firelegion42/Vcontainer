using UnityEngine;
using VContainer;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;
    private ChasingEnemyFactory _enemyFactory;

    [Inject]
    private void Construct(ChasingEnemyFactory enemyFactory)
    {
        _enemyFactory = enemyFactory;
    }
      
        
    public void SummonEnemy()
    {
        Debug.Log("Button Pressed");
     var go = _enemyFactory.Create();
     go.transform.position = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        var randomX = Random.Range(_minX, _maxX);
        var randomZ = Random.Range(_minZ, _maxZ);
        return new Vector3(randomX, 0f, randomZ);
    }
}
