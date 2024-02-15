using UnityEngine;

//Provides a basic health system with the ability to take damage
public class EnemyHealthSystem : MonoBehaviour, IHealth
{
    [SerializeField] private float _health;

    //Current health of the object
    public float Health 
    {  get => _health;  
       set => _health = value; }

    //Reduce the health by the damage amount and destroys the GameObject if the health falls below zero
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
