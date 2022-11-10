using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Particles : MonoBehaviour
{

    public Transform spawner;
    public Transform jumper;
    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {
    }
    void Jumping()
    {
        Instantiate(dust, jumper.position, jumper.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)) Instantiate(dust, spawner.position, spawner.rotation);
        if (Input.GetKeyDown("space")) Jumping();
    }
}
