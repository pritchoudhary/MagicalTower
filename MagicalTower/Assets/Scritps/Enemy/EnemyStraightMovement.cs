using UnityEngine;

public class EnemyStraightMovement : MonoBehaviour, IMovement
{
    //Moves the attached gameobject towards a target position at a specified speed.

    public void Move(Transform transform, Vector3 targetPosition, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
