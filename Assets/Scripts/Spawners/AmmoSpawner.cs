using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _dynamicObjectsTransform;
    [SerializeField] private GameObject _ammoPrefab;

    private GameObject _ammo;

    private Vector3 _lowerLeftCorner;
    private Vector3 _topRightCorner;

    private void Start()
    {
        _lowerLeftCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0 ,Camera.main.nearClipPlane));
        _topRightCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1 ,Camera.main.nearClipPlane));
        SpawnAmmo();
    }
    private void Update()
    {
        SpawnAmmo();
    }
    public void SpawnAmmo()
    {
        if (_ammo == null)
        {
            float randomX = Random.Range(_lowerLeftCorner.x, _topRightCorner.x);
            float randomY = Random.Range(_lowerLeftCorner.y, _topRightCorner.y);
            _ammo = Instantiate(_ammoPrefab, new Vector2(randomX, randomY), Quaternion.identity, _dynamicObjectsTransform);
        }   
    }
}
