using UnityEngine;

//Base class for all spells with common properties and an abstract CastSpell method
public abstract class Spell : ScriptableObject
{
    public float _coolDown;
    public GameObject _projectilePrefab;
    public bool _requiresTarget;

    //Abstract method to be implemented by concrete spell classes
    public abstract void CastSpell(Vector3 spawnPosition, Transform target = null);
}
