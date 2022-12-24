using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Player Sounds")]
    public AudioClip _playerShootSound;
    public AudioClip _playerDeathSound;

    [Header("Enemy Sounds")]
    public AudioClip _enemyShootSound;
    public AudioClip _enemyDeathSound;

    public static SoundManager instance;

    private AudioSource _audioSourse;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        _audioSourse= GetComponent<AudioSource>();
    }

    public void PlayerShootSound()
    {
        _audioSourse.PlayOneShot(_playerShootSound);
    }
    public void PlayerDeathSound()
    {
        _audioSourse.PlayOneShot(_playerDeathSound);
    }

    public void EnemyShootSound()
    {
        _audioSourse.PlayOneShot(_enemyShootSound);
    }
    public void EnemyDeathSound()
    {
        _audioSourse.PlayOneShot(_enemyDeathSound);
    }
}
