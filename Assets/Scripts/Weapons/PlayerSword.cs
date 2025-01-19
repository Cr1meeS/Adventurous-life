using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer  == 8)
        {       
            Transform enemy = other.gameObject.transform.parent;

            if (enemy.TryGetComponent<IDamageable>(out var instance))
            {
                instance.ApplyDamage(_damage);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 7)
        {
            Transform enemy = collision.gameObject.transform.parent;

            if (enemy.TryGetComponent<IDamageable>(out var instance))
            {
                instance.ApplyDamage(_damage);
            }
        }
    }
}
