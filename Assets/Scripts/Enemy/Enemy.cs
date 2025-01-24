using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    [Header("Movement")]
    [SerializeField] 
    private float speed;
    [SerializeField] 
    private Transform[] moveSpots;
    private int randomSpot;

    [Space(13)]
    
    [Header("Health")]
    [SerializeField] 
    private int maxHealth;
    private int currentHealth;
    [SerializeField] 
    private EnemyHealthBar healthBar;

    [Space(13)]
    
    [Header("Attack")]
    [SerializeField] 
    private GameObject bullet;
    [SerializeField] 
    private Transform spawnBulletPosition;
    [SerializeField] 
    private int damage;
    [SerializeField] 
    private float shootForce;
    [SerializeField] 
    private float attackDelay;
    private float currentAttackDelay;

    private bool playerNoticed;

    private void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        currentHealth = maxHealth;
        healthBar.SetHealthText(currentHealth, maxHealth);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            moveSpots[randomSpot].position,
            speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < .2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }

        if (playerNoticed)
        {
            transform.LookAt(player.transform);
            
            if (currentAttackDelay <= 0)
            {
                Attack();
                currentAttackDelay = attackDelay;
            }
            else
            {
                currentAttackDelay -= Time.deltaTime;
            }
        }
        else
        {
            transform.LookAt(moveSpots[randomSpot]);
        }
    }

    public void DamageEnemy(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(this.transform.parent.gameObject);
            GameManager.Instance.KillEnemy();
        }

        healthBar.UpdateHealthText(currentHealth);
    }

    private void Attack()
    {
        if (bullet != null && player != null)
        {
            GameObject bulletPrefab = Instantiate(bullet, spawnBulletPosition.position, Quaternion.identity);
            bulletPrefab.GetComponent<BulletEnemy>().SetBulletSpecifications(damage, shootForce);
            bulletPrefab.GetComponent<BulletEnemy>().SetPlayerPosition(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNoticed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNoticed = false;
        }
    }
}
