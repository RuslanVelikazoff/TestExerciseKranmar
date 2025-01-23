using System.Collections;
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
            //kill
        }

        healthBar.UpdateHealthText(currentHealth);
    }

    private void Attack()
    {
        GameObject currentBullet = Instantiate(bullet, spawnBulletPosition.position, Quaternion.identity);
        Vector3 direction = player.transform.position;
        
        currentBullet.GetComponent<Bullet>().SetBulletDamage(damage);
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        currentBullet.transform.position = Vector3.MoveTowards(spawnBulletPosition.position,
            player.transform.position, shootForce);
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
