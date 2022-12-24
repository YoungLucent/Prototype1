using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField]  private float _speed;

    private bool _isMoving;
    private Vector3 _targetPosition;

    private void Update()
    {       
        SetTargetPosition();
        Move();
    }
    private void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.z = transform.position.z;
            _isMoving = true;
        }
    }
    private void Move()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            if (transform.position == _targetPosition)
            {
                _isMoving = false;
            }
        }      
    }
    
}
