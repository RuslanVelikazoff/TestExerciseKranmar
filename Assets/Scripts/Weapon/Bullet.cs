using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] 
    private float lifeTime;

    private void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }
}
