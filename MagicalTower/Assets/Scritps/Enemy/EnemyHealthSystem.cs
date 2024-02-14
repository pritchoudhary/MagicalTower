using UnityEngine;

//Provides a basic health system with the ability to take damage
public class EnemyHealthSystem : MonoBehaviour, IHealth
{
    //Current health of the object
    public float Health {  get;  set; }

    //Reduce the health by the damage amount and destroys the GameObject if the health falls below zero
    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
            Destroy(gameObject);
    }
}
