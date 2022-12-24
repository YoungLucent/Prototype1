using UnityEngine;

public class GameResult : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DefeatScreen _defeatScreen;
    [SerializeField] private WinScreen _winScreen;

    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerFire _playerFire;
    private void Awake()
    {
        Time.timeScale = 1;
        _playerHealth.OnDefeat += Defeat;
        _playerFire.OnWin += Win;
    }
    private void OnDestroy()
    {
        _playerHealth.OnDefeat -= Defeat;
        _playerFire.OnWin -= Win;
    }
    private void Win()
    {
        _winScreen.Show();
        Time.timeScale = 0;
    }
    private void Defeat()
    {
        _defeatScreen.Show();
        Time.timeScale = 0;
    }

}
