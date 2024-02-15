using UnityEngine;

//Base class for projectiles to handle common behaviour
public class Projectile : MonoBehaviour
{
    protected float _speed;
    protected float _damage;
    protected float _explosionRadius;

    protected virtual void Update()
    {
        //Move the projectile forward each frame
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Check for enemey and deal damage
    }
}
