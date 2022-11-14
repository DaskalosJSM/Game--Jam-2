using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Stats;

    [Range(0.0f, 100.0f)]
    public float Health;
     // Arrows
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;

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
        arrow1 = GameObject.Find("Arrow1");
        arrow2 = GameObject.Find("Arrow2");
        arrow3 = GameObject.Find("Arrow3");
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
        if (weaponPiece==1)
        {
            arrow1.SetActive(true);
        }
         if (weaponPiece==2)
        {
            arrow2.SetActive(true);
        }
         if (weaponPiece>=3)
        {
            arrow3.SetActive(true);
        }
         if (weaponPiece<=0)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
        }
    }
}
