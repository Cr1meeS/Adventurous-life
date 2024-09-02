using UnityEngine;

public class EnemySword : MonoBehaviour
{
    [SerializeField] private float _damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Transform player = other.gameObject.transform.parent;

            if (player.TryGetComponent<IDamageable>(out var instance))
            {
                instance.ApplyDamage(_damage);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != 8 )
        {
            Transform player = collision.gameObject.transform.parent;

            if (player.TryGetComponent<IDamageable>(out var instance))
            {
                instance.ApplyDamage(_damage);
            }
        }

    }
}
