using UnityEngine;

public interface IHealth
{
    float Health { get; set; }

    //Method to apply damage to the object.
    void TakeDamage(float damage);
}
