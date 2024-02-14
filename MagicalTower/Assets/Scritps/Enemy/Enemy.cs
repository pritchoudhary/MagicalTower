using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Speed at which the enemy moves
    [SerializeField] private float _speed;
    //Starting health of the enemy
    [SerializeField] private float _initalHealth;

    private IMovement _movement;
    private IHealth _health;

    private void Awake()
    {
        //Finds components attached to the same gameobject that implements the interfaces
        _movement = GetComponent<IMovement>();
        
        //Initalizes the health component
        if (TryGetComponent(out _health))
            _health.Health = _initalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Moves the enemy towards a target position each frame.
    }

    //Method to apply damage to the enemy
    public void TakeDamage(float damage)
    {
        _health?.TakeDamage(damage);
    }

    public void Initialize()
    {
        if (_health != null)
            _health.Health = _initalHealth;

        gameObject.SetActive(true);


    }
}
