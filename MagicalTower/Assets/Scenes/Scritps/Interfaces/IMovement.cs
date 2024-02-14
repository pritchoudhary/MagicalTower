using UnityEngine;

public interface IMovement
{
    //Defines a method to move the object towards a target position at a given speed
    void Move(Transform transform, Vector3 targetPosition, float speed);
}
