using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime = 8f;
    float coutdown;
    public float speed = 20f;
    public Rigidbody rb;
    public EnemyIA enemyLife;
    // Start is called before the first frame update
    void Start()
    {
        coutdown = Lifetime;
        rb.velocity = speed * transform.forward;
    }

    void Update()
    {
        coutdown -= Time.deltaTime;
        if (coutdown <= 0f)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyLife = other.gameObject.GetComponent<EnemyIA>();
            enemyLife.TakeDamage(25);

            Destroy(this.gameObject);
        }
        //rb.velocity = speed * -(transform.forward);
        Destroy(this.gameObject);
    }
}
