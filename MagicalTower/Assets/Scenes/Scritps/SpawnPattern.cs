using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnPattern", menuName = "Spawn Pattern", order = 51)]
public class SpawnPattern : ScriptableObject
{
    //Define the spawn pattern data 
    public SpawnInfo[] _spawnInfos;
    private int _cuurentIndex = 0;

    //Difficulty settings
    public float _difficultyIncreaseRate = 0.95f;
    public float _minDelay = 1f;

    public SpawnInfo GetNextSpawn()
    {
        if (_cuurentIndex >= _spawnInfos.Length) 
            _cuurentIndex = 0;

        SpawnInfo info = _spawnInfos[_cuurentIndex++];

        //Decrease the delay to increase the difficulty, but clamp to minDelay 
        info.Delay = Mathf.Max(_minDelay, info.Delay * _difficultyIncreaseRate);

        return info;
    }
}
