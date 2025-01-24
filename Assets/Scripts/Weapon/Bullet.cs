using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float lifeTime;
    [SerializeField]
    private int damage;

    private void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }

    public void SetBulletDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponentInParent<Enemy>().DamageEnemy(damage);
        }

        Destroy(this.gameObject);
    }
}
