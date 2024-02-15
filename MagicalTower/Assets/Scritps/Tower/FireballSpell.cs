using UnityEngine;

[CreateAssetMenu(fileName = "FireballSpell", menuName = "Spells/Fireball")]
public class FireballSpell : Spell
{
    //Casts a spell towards a random direction
    public override void CastSpell(Vector3 spawnPosition, Transform target = null)
    {
        var projectileInstance = Instantiate(_projectilePrefab, spawnPosition, Quaternion.identity);
        var fireBall = projectileInstance.GetComponent<FireballProjectile>();

        GameObject floor = GameObject.Find("Floor");
        MeshRenderer floorMeshRenderer = floor.GetComponent<MeshRenderer>();
        Bounds floorBounds = floorMeshRenderer.bounds;

        //Generate a random position within the bounds of the floor
        float randomX = Random.Range(floorBounds.min.x, floorBounds.max.x);
        float randomZ = Random.Range(floorBounds.min.z, floorBounds.max.z);

        Vector3 randomTargetPosition = new(randomX, floor.transform.position.y, randomZ);

        fireBall.Initialize(_damage, _projectileSpeed, _explosionRadius, randomTargetPosition, _gravity, _launchAngle);
    }
}
