using UnityEngine;

//Inherits from Projectile, adding fireball-specific behaviour 
public class FireballProjectile : Projectile
{
    public void Initialize(float damage, float speed, float radius, Vector3 targetPosition, float gravity, float launchAngle)
    {
        _damage = damage;
        _explosionRadius = radius;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if(!rigidbody)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }


        //Add check for invalid velocity
        if (float.IsNaN(rigidbody.velocity.x) || float.IsNaN(rigidbody.velocity.y) || float.IsNaN(rigidbody.velocity.z)) { return; }

        rigidbody.useGravity = true;
        rigidbody.velocity = ProjectileArcUtility.CalculateArcVelocity(transform.position, targetPosition, launchAngle, gravity);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent<EnemyHealthSystem>(out var enemyHealthSystem))
                enemyHealthSystem.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor"))
            Destroy(gameObject); //Destroy the projectile after hitting the target
    }
}
