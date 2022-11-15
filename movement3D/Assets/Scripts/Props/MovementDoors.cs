using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDoors : MonoBehaviour
{
    public SpawnManager dungeon;
    public bool dungeonDoor;
    public GameObject cover;
    public List<Transform> waypoints;
    public float moveSpeed;
    private int target;
    public bool Opening;
    public bool cantBeOpen;
    private Vector3 inicialPos;
    public soundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        dungeon = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        inicialPos = this.transform.position;
        cover.SetActive(true);
    }
    private void Update()
    {
        if (dungeonDoor == true)
        {
            if (Opening == true && dungeon.spawnersActive == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);

            }
            if (dungeon.spawnersActive == true)
            {
                transform.position = inicialPos;
            }
            if (dungeon.spawnersActive == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
            }
        }
        if (cantBeOpen == true)
        {
            transform.position = transform.position;
        }
        if (Opening == true && dungeonDoor == false)
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
            soundManager.Instance.Play(7);
            Opening = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && cantBeOpen == true)
        {
            soundManager.Instance.Play(3);
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
