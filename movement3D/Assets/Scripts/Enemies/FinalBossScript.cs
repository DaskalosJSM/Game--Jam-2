using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossScript : MonoBehaviour
{
    public EnemyIA Enemy;
    public GameManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<EnemyIA>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.health == 0)
        {
            Manager.YouWin();
        }
    }
    
}
