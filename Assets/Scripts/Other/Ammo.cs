using UnityEngine;

public class Ammo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerFire playerFire))
        {
            playerFire.Shoot();
            Destroy(gameObject);
        }
    }
}
