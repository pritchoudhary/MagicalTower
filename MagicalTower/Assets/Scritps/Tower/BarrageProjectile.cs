using UnityEngine;

//Inherits from Projectile customized for Barrage projectiles targetting individual enemies
public class BarrageProjectile : Projectile
{
    private Transform _target;
    private Vector3 _targetInitalVelocity;
    private float _timeToTarget;

    public void Initialize(float damage, Vector3 initialVelocity, Transform target, Vector3 targetVelocity)
    {
        //Add check for invalid velocity
        if (float.IsNaN(initialVelocity.x) || float.IsNaN(initialVelocity.y) || float.IsNaN(initialVelocity.z)) { return; }

        _damage = damage;
        _target = target;
        _targetInitalVelocity = targetVelocity;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if(!rigidbody)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        rigidbody.useGravity = false;
        rigidbody.velocity = initialVelocity;

        //Estimate time to target based on inital distance and velocity
        _timeToTarget = (target.position - transform.position).magnitude/initialVelocity.magnitude;
    }

    protected override void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject); //Destroy the projectile if the target is no longer valid
            return;
        }

        //Predict the future position of the target
        Vector3 predictedPosition = _target.position + _targetInitalVelocity * _timeToTarget;

        //Adjust the projectile's trajectory towards the predicted position
        Vector3 directionToPredictedPosition = (predictedPosition - transform.position).normalized;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = directionToPredictedPosition * rigidbody.velocity.magnitude;

        //update the projectile's rotation to face its moving direction
        if (rigidbody.velocity != Vector3.zero)
            Quaternion.LookRotation(rigidbody.velocity.normalized);

    }

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.TryGetComponent<EnemyHealthSystem>(out var enemyHealthSystem))
                enemyHealthSystem.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Floor"))
            Destroy(gameObject); //Destroy the projectile after hitting the target
    }
}
