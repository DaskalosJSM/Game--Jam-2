using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDoors : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider) {

        if(collider.CompareTag("Player"))
        {
            Destroy(gameObject); 
            Debug.Log("prueba rama");
        }
    }

}
