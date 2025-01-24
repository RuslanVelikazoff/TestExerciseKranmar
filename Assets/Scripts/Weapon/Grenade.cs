using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private GameObject grenadePrefab;
    [SerializeField] 
    private Transform throwPosition;
    [SerializeField] 
    private float throwForce = 10f;
    [SerializeField] 
    private float upwardsForce = 5f;
    [SerializeField] 
    private float throwDelay = .5f;
    private float lastThrowTime;
    [SerializeField] 
    private int damage;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastThrowTime > throwDelay)
        {
            ThrowGrenade();
            lastThrowTime = Time.time;
        }
    }

    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPosition.position, throwPosition.rotation);

        Rigidbody grenadeRigidbody = grenade.GetComponent<Rigidbody>();

        Vector3 throwDirection = throwPosition.forward;

        Vector3 finalForce = (throwDirection * throwForce) + (Vector3.up * upwardsForce);

        grenadeRigidbody.AddForce(finalForce, ForceMode.Impulse);

        StartCoroutine(grenade.GetComponent<GrenadePrefab>().Explosion(damage));
    }
}
