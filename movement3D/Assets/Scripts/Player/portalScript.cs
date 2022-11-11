using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public PlayerStats Stats;
    public GameObject target;
    public GameManager Manager;
    [SerializeField] bool loopPortal;

    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Stats = GameObject.Find("GameStatsManager").GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && loopPortal == true)
        {
            other.transform.position = target.transform.position;
        }
        if (other.tag == "Player" && Stats.weaponPiece == 1 && loopPortal == false)
        {
            Manager.Level2();
        }
        if (other.tag == "Player" && Stats.weaponPiece == 2 && loopPortal == false)
        {
            Manager.Level3();
        }
        if (other.tag == "Player" && Stats.weaponPiece == 3 && loopPortal == false)
        {
            Manager.FinalBoss();
        }
    }
}
