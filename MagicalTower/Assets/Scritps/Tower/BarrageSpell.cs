using UnityEngine;

[CreateAssetMenu(fileName = "BarrageSpell", menuName = "Spells/Barrage")]
public class BarrageSpell : Spell
{
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;

    //Casts a barrage spell for each target visible on the screen
    public override void CastSpell(Vector3 spawnPosition, Transform target)
    {
        var projectileInstance = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);
        var barrage = projectileInstance.GetComponent<BarrageProjectile>();
        barrage.Initialize(_damage, _projectileSpeed,target);
    }
}
