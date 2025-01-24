using System.Collections;
using UnityEngine;

public class GrenadePrefab : MonoBehaviour
{
    [SerializeField] 
    private float explosionDelay;
    
    public IEnumerator Explosion(int damage)
    {
        yield return new WaitForSeconds(explosionDelay);

        Collider[] enemies = Physics.OverlapSphere(transform.position,
            5f, LayerMask.GetMask("Enemy"));

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.GetComponent<Enemy>().DamageEnemy(damage);
        }

        Destroy(this.gameObject);
    }
}
