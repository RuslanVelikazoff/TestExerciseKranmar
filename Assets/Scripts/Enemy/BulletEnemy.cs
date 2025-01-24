using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] 
    private float lifeTime = 3f;
    private float speed;
    private int damage;
    private Transform player;
    private Vector3 direction;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    public void SetPlayerPosition(Transform target)
    {
        player = target;
        direction = (target.position - transform.position).normalized;
    }

    public void SetBulletSpecifications(int damage, float speed)
    {
        this.speed = speed;
        this.damage = damage;
    }

    private void Update()
    {
        if (player != null)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerHealth.Instance.DamagePlayer(damage);
        }

        Destroy(this.gameObject);
    }
}
