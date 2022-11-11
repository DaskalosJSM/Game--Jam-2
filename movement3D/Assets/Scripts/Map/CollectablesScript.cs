using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public PlayerStats Stats;
    [SerializeField] bool Life;
    
    [SerializeField] bool Anmo;
    
    [SerializeField] bool Key;
    void Start()
    {
        Stats = GameObject.Find("GameStatsManager").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Key == true)
        {
            Destroy(gameObject);
            Stats.weaponPiece += 1;
            Key = false;
        }
        if (other.gameObject.CompareTag("Player") && Life == true)
        {
            Destroy(gameObject);
            Stats.Health += 25;
            Life = false;
        }
         if (other.gameObject.CompareTag("Player") && Anmo == true)
        {
            Destroy(gameObject);
            Stats.Anmo += 5;
            Anmo = false;
        }
    }
}
