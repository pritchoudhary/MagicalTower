using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] private float _health = 200f;
    [SerializeField] private Image _healthBar;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        _healthBar.fillAmount = _health / 200f;

        if (_health <= 0)
        {
            Destroy(gameObject);
            GameManager._gameManagerInstance.EndGame();
        }
            
    }


}
