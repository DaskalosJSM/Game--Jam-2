using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlelife : MonoBehaviour
{
    public float lifetime;
    public float countdown;
    // Start is called before the first frame update
    void Start()
    {
        countdown = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f) Destroy(gameObject);
    }
}
