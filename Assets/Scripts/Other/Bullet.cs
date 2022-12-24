using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _targetPrefab;

    [Header("Bullet Settings")]
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _bulletDirection;
    private void Start()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        _rigidbody2D.velocity = _bulletDirection.normalized * _bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_targetPrefab.tag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    } 
    public void ShootingDirection(Vector3 direction)
    {
        _bulletDirection = direction;
    }
}
