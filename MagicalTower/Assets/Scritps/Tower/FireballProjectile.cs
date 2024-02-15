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

        rigidbody.useGravity = true;
        rigidbody.velocity = ProjectileArcUtility.CalculateArcVelocity(transform.position, targetPosition, launchAngle, gravity);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        //Implement explosion logic
    }
}
