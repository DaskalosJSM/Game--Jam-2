using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public PlayerStats Stats;
    // Start is called before the first frame update
    void Start()
    {
        Stats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Stats.weaponPiece += 1;
        }
    }
}
