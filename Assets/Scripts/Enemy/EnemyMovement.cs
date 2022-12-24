using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _playerTransform;

    [Header("Movement Settings")]
    [SerializeField] private float _speed;
    

    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
    }
}
