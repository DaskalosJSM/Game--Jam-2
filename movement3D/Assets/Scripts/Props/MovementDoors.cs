using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDoors : MonoBehaviour
{
    public GameObject cover;
    public List<Transform> waypoints;
    public float moveSpeed;
    private int target;
    public bool Opening;
     public bool cantBeOpen;

    private void Start()
    {
        cover.SetActive(true);
    }
    private void Update()
    {
        if (cantBeOpen == true)
        {
            transform.position = transform.position;
        }
        if (Opening == true)
        {

            transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        if (transform.position == waypoints[target].position)
        {
            if (target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            cover.SetActive(false);
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && cantBeOpen == false)
        {
            Opening = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            cover.SetActive(true);
        }
    }

}
