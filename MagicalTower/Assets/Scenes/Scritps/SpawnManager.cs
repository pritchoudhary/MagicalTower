using System.Collections;
using UnityEngine;

//Struct to hold information about each spwan
[System.Serializable]
public struct SpawnInfo
{
    public int TypeIndex; //index of the enemy type to spawn
    public float Delay; //Delay before the next spawn
}

//SpawnManager class responsible for spawning enemies based on a define spawn pattern
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private SpawnPattern _spawnPattern; //Reference to a scriptable object that defines the spawn rates and patterns
    [SerializeField] private Transform _floorTransform; //Reference to the floor of the level to get the bounds

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    //Coroutine to handle the spawning of enemies
    private IEnumerator SpawnRoutine()
    {
        Bounds floorBounds = _floorTransform.GetComponent<MeshRenderer>().bounds;

        while (true)
        {
            SpawnInfo spawnInfo = _spawnPattern.GetNextSpawn();
            //Generate random position within the floor bounds
            Vector3 randomPosition = new(Random.Range(floorBounds.min.x, floorBounds.max.x), _floorTransform.position.y, Random.Range(floorBounds.min.z,floorBounds.max.z));
            yield return new WaitForSeconds(spawnInfo.Delay); //Wait for specified delay before spawning the next enemy

            
            _enemyFactory.GetEnemy(spawnInfo.TypeIndex, randomPosition, Quaternion.identity);
        }
    }
}
