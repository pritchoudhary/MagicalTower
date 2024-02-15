using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManagerInstance { get; private set; }

    [SerializeField] private GameObject _gameOverText;

    private void Awake()
    {
        if (_gameManagerInstance != null && _gameManagerInstance != this)
            Destroy(gameObject);
        else
        {
            _gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void EndGame()
    {
        _gameOverText.SetActive(true);
        Time.timeScale = 0.0f; //Stop the game
    }
}
