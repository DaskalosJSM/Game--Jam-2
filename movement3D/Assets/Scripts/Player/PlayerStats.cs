using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Stats;

    [Range(0.0f, 100.0f)]
    public float Health;
    
    [Range(0, 30)]
    public int Anmo;
    public int weaponPiece;
    public GameManager Manager;
    private void Awake()
    {
        
        if (Stats != null && Stats != this)
        {
            Destroy(this);
        }
        else
        {
            Stats = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (Health <= 0)
        {
            Manager.GameOver();
            Health = 100;
            weaponPiece = 0;
            Anmo = 10;
        }
    }
}
