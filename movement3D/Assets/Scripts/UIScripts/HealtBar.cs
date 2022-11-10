using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{

    private Image HealthBar;

    [Range(0.0f, 100.0f)]
    public float CurrentHealth;
    public float MaxHealt = 100f;
    public PlayerStats Player;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealt;
    }
}
