using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Lifetime = 8f;
    float coutdown;
    public float speed = 20f;
    public Rigidbody rb ;
    // Start is called before the first frame update
    void Start()
    {
        coutdown = Lifetime;
        rb.velocity = speed * transform.forward; 
    }

    void Update() {
    coutdown -= Time.deltaTime; 
    if(coutdown <= 0f)
    {
        Destroy(gameObject);
    }   
    }
    void OnCollisionEnter(Collision other) 
    {
       rb.velocity = speed * -(transform.forward);
    }
}
