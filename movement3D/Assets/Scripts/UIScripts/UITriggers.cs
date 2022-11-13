using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITriggers : MonoBehaviour
{
    public GameObject sprite;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sprite.SetActive(true);
        }
    }
       private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sprite.SetActive(false);
        }
    }
}
