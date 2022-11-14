using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public PlayerStats Stats;
    public UIManager UImanager;
    [SerializeField] bool Life;

    [SerializeField] bool Anmo;

    [SerializeField] bool Keylvl2;
    [SerializeField] bool Keylvl3;
    [SerializeField] bool Keylvlboss;
    void Start()
    {
        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();
        Stats = GameObject.Find("GameStatsManager").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Keylvl2 == true)
        {
            UImanager.indicador = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 1;
        }
        if (other.gameObject.CompareTag("Player") && Keylvl3 == true)
        {
            UImanager.indicador = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 2;
        }
        if (other.gameObject.CompareTag("Player") && Keylvlboss == true)
        {
            UImanager.indicador = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 3;
        }
        if (other.gameObject.CompareTag("Player") && Life == true && Stats.Health < 100)
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
