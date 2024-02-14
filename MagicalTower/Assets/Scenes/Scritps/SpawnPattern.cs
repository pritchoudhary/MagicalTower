using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnPattern", menuName = "Spawn Pattern", order = 51)]
public class SpawnPattern : ScriptableObject
{
    //Define the spawn pattern data 
    public SpawnInfo[] _spawnInfos;
    private int _cuurentIndex = 0;

    public SpawnInfo GetNextSpawn()
    {
        if (_cuurentIndex >= _spawnInfos.Length) 
            _cuurentIndex = 0;

        return _spawnInfos[_cuurentIndex++];
    }
}
