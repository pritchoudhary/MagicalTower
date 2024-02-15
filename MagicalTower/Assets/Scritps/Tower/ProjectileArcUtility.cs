using UnityEngine;

public static class ProjectileArcUtility
{
    // This static method calculates the initial velocity vector needed to hit a target with a given angle and gravity.
    public static Vector3 CalculateArcVelocity(Vector3 origin, Vector3 target, float angle, float gravity)
    {
        Vector3 direction = target - origin; // Get the direction to the target
        float h = direction.y;  // Get the height difference
        direction.y = 0;  // Retain only the horizontal direction
        float distance = direction.magnitude;  // Get the horizontal distance
        float a = angle * Mathf.Deg2Rad;  // Convert angle to radians
        direction.y = distance * Mathf.Tan(a);  // Set the height direction to the tangent of the angle multiplied by the distance
        distance += h / Mathf.Tan(a);  // Correction for height difference

        // Calculate velocity
        float velocity = Mathf.Sqrt(distance * gravity / Mathf.Sin(2 * a));
        return velocity * direction.normalized;  // Return the velocity vector
    }
}