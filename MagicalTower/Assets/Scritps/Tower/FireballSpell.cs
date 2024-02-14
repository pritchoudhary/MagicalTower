using UnityEngine;

[CreateAssetMenu(fileName = "FireballSpell", menuName = "Spells/Fireball")]
public class FireballSpell : Spell
{
    [SerializeField] private float _damage;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _explosionRadius;

    //Casts a spell towards a random direction
    public override void CastSpell(Vector3 spawnPosition, Transform target = null)
    {
        var projectileInstance = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);
        var fireBall = projectileInstance.GetComponent<FireballProjectile>();
        fireBall.Initialize(_damage, _projectileSpeed, _explosionRadius);
    }
}
