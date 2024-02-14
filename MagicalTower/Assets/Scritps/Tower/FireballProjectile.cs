using UnityEngine;

//Inherits from Projectile, adding fireball-specific behaviour 
public class FireballProjectile : Projectile
{
    [SerializeField] private float _explosionRadius;

    public void Initialize(float damage, float speed, float radius)
    {
        _damage = damage; 
        _speed = speed;
        _explosionRadius = radius;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        //Implement explosion logic
    }
}
