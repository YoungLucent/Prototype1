using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _dynamicObjectsTransform;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _playerTransform;

    [Header("Shoot Settings")]   
    [SerializeField] private float _timeBetweenShots;
    
    private GameObject _currentBullet;
    private float _currentTimeBetweenShots;

    private Vector3 _direction;
    private float _angle;

    private void Start()
    {
        _currentTimeBetweenShots = _timeBetweenShots;
    }
    private void FixedUpdate()
    {
        RotateToPlayer();
        Shoot();     
    }

    public void Shoot()
    {
        if (_currentTimeBetweenShots <= 0)
        {
            SoundManager.instance.EnemyShootSound();
            _currentBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(0, 0, _angle), _dynamicObjectsTransform);
            _currentBullet.GetComponent<Bullet>().ShootingDirection(_direction);
            _currentTimeBetweenShots = _timeBetweenShots;
        }
        else
        {
            _currentTimeBetweenShots -= Time.deltaTime;
        }       
    }
  
    private void RotateToPlayer()
    {
        _direction = _playerTransform.position - transform.position;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
