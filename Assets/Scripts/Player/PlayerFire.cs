using System;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _dynamicObjectsTransform;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject[] _enemies;

    [Header("Bullet Settings")]   
    [SerializeField] private float _bulletSpeed;

    private GameObject _currentBullet;  
    private Vector3 _direction;
    private float _angle;
    private GameObject _closestEnemy = null;

    public event Action OnWin;

    private void Update()
    {      
        RotateToEnemy();
    }

    private void RotateToEnemy()
    {
        if (ClosestEnemy() != null)
        {
            _direction = ClosestEnemy().transform.position - transform.position;
            _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, _angle);
        }
        else
        {
            OnWin?.Invoke();
        }
    }

    private GameObject ClosestEnemy()
    {       
        float smallestDistance = Mathf.Infinity;
        foreach (GameObject enemy in _enemies)
        {
            if (enemy != null)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (smallestDistance > distance)
                {
                    smallestDistance = distance;
                    _closestEnemy = enemy;
                }
            }           
        }
        return _closestEnemy; 
    }

    public void Shoot()
    {
        SoundManager.instance.PlayerShootSound();        
        _currentBullet = Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(0, 0, _angle), _dynamicObjectsTransform);
        _currentBullet.GetComponent<Bullet>().ShootingDirection(_direction);
    }
}
