using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnmyHealtbarUI : MonoBehaviour
{

    private Image HealthBar;

    [Range(0.0f, 1000.0f)]
    public float CurrentHealth;
    public float MaxHealt = 1000f;
    public EnemyIA Enemy;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Enemy = GameObject.Find("Final Boss").GetComponent<EnemyIA>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Enemy.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}
