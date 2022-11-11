using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public PlayerStats Stats;
    void Start()
    {
        Stats = GameObject.Find("GameStatsManager").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Stats.weaponPiece += 1;
        }
    }
}
