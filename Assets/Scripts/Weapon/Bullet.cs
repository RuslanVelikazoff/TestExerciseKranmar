using System;
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
        Destroy(this.gameObject);
    }
}
