using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image _healthBarFilling;
    [SerializeField] private Health _health;

    private Camera _camera;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
        _camera = Camera.main;
    }
    private void LateUpdate()
    {
        SetRotation();
    }
    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }
    private void OnHealthChanged(float valueAsPercentage)
    {
        _healthBarFilling.fillAmount = valueAsPercentage;
    }
    private void SetRotation()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
