using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

//Struct to hold information about each spwan
[System.Serializable]
public struct SpawnInfo
{
    public int TypeIndex; //index of the enemy type to spawn
    public Vector3 Position;
    public float Delay; //Delay before the next spawn
}

//SpawnManager class responsible for spawning enemies based on a define spawn pattern
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private SpawnPattern _spawnPattern; //Reference to a scriptable object that defines the spawn rates and patterns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    //Coroutine to handle the spawning of enemies
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnInfo spawnInfo = _spawnPattern.GetNextSpawn();
            yield return new WaitForSeconds(spawnInfo.Delay); //Wait for specified delay before spawning the next enemy

            //Spawn enemy using the factory
            var enemy = _enemyFactory.GetEnemy(spawnInfo.TypeIndex, spawnInfo.Position, Quaternion.identity);
        }
    }
}
