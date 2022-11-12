using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera my_camera;
    private void Start()
    {
        my_camera = GameObject.Find("Main Camera").GetComponent<Camera>(); ;
    }
    void Update()
    {
        transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.back,
        my_camera.transform.rotation * Vector3.up);
    }

}
