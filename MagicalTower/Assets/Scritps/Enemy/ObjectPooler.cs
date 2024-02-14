using System.Collections.Generic;
using UnityEngine;

//Generic Object Pooler class that can be used to pool any type of GameObject component
public class ObjectPooler<T> where T : Component
{
    private readonly T _prefab; //The prefab to be pooled
    private readonly Queue<T> _objects = new(); //Queue to hold the pooled objects

    //Constructor taking the prefab to be pooled
    public ObjectPooler(T prefab)
    {
        _prefab = prefab;
    }

    //Method to get an object from the pool, or create a new one if the pool is empty
    public T Get()
    {
        if (_objects.Count == 0)
            AddObjects(1); //Add object to the pool if empty

        return _objects.Dequeue();
    }

    //Method to return an object to the pool
    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false); //Deactivate the gameobject before returning it to the pool
        _objects.Enqueue(objectToReturn);
    }

    //Method to add objects to the pool
    private void AddObjects(int count)
    {
        for(int i = 0; i < count; i++)
        {
            var newObject = Object.Instantiate(_prefab);
            newObject.gameObject.SetActive(false);
            _objects.Enqueue(newObject);
        }
    }
}
