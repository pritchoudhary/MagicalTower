using UnityEngine;

//Inherits from Projectile customized for Barrage projectiles targetting individual enemies
public class BarrageProjectile : Projectile
{
    private Transform _target;

    public void Initialize(float damage, float speed, Transform target)
    {
        _damage = damage;
        _speed = speed;
        _target = target;
    }

    protected override void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject); //Destroy the projectile if the target is no longer valid
            return;
        }

        //Calculate direction to the target
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.position += _speed * Time.deltaTime * direction; //Move towards the target
        transform.rotation = Quaternion.LookRotation(direction); //Rotation to face the target
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        //Apply damage
        Destroy(gameObject); //Destroy the projectile after hitting the target
    }
}
