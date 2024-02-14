using UnityEngine;

//EnemyFactory class responsible for creating and managing pools of different enemy types
public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs; //Array for different enemy prefabs
    private ObjectPooler<Enemy>[] _enemyPools; //Array of pools for each enemy type

    private void Awake()
    {
        //Initalize the pools array based on the number of enemy prefabs\
        _enemyPools = new ObjectPooler<Enemy>[_enemyPrefabs.Length];

        for(int i = 0; i < _enemyPools.Length; i++)
        {
            //Create new ObjectPooler for each enemy type
            _enemyPools[i] = new ObjectPooler<Enemy>(_enemyPrefabs[i]);
        }
    }

    //Method to get an enemy of a specific type from the corresponding pool
    public Enemy GetEnemy(int typeIndex, Vector3 position, Quaternion rotation)
    {
        if(typeIndex < 0 || typeIndex >= _enemyPools.Length)
        {
            Debug.LogError("Requested enemy type index out of range");
            return null;
        }

        var enemy = _enemyPools[typeIndex].Get(); //Get an enemy from the pool
        enemy.transform.position = position;
        enemy.transform.rotation = rotation;

        enemy.gameObject.SetActive(true);
        enemy.Initialize();

        return enemy;
    }

    //Method to return an enemy from the corresponding pool
    public void ReturnEnemy(Enemy enemy, int typeIndex)
    {
        if(typeIndex < 0 || typeIndex >= _enemyPools.Length)
        {
            Debug.LogError("Trying to return an enemy to a non-existant pool");
            return;
        }

        _enemyPools[typeIndex].ReturnToPool(enemy);
    }
}