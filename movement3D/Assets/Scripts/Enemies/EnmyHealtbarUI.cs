using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnmyHealtbarUI : MonoBehaviour
{

    private Image HealthBar;

    [Range(0.0f, 1500.0f)]
    public float CurrentHealth;
    public float MaxHealt = 1500;
    public EnemyIA Enemy;
    public GameManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Enemy = GameObject.Find("Final Boss").GetComponent<EnemyIA>();
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Enemy.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealt;
        if (Enemy.health>=0)
        {
            Invoke("EnemyisDeath", 3.0f);
        }
    }
    void EnemyisDeath()
    {
        Manager.YouWin();
    }
}
