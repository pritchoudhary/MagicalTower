using UnityEngine;

[CreateAssetMenu(fileName = "BarrageSpell", menuName = "Spells/Barrage")]
public class BarrageSpell : Spell
{
    //Casts a barrage spell for each target visible on the screen
    public override void CastSpell(Vector3 spawnPosition, Transform target = null)
    {
        foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy")) 
        {
            var projectileInstance = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);
            var barrage = projectileInstance.GetComponent<BarrageProjectile>();

            Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();
            Vector3 enemyVelocity = enemyRigidbody != null ? enemyRigidbody.velocity : Vector3.zero;

            Vector3 velocity = ProjectileArcUtility.CalculateArcVelocity(spawnPosition, enemy.transform.position, _launchAngle, _gravity);
            barrage.Initialize(_damage, velocity, enemy.transform, enemyVelocity);
        }

    }
}
