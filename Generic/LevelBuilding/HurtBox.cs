using UnityEngine;

public class HurtBox : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private bool onTrigger = false;
    [SerializeField]
    private bool onCollision = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onCollision)
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            damageable?.TakeDamage(damage);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTrigger)
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            damageable?.TakeDamage(damage);
        }
    }
}
