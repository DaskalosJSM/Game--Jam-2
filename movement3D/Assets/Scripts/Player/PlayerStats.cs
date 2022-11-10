using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Range(0.0f, 100.0f)]
    public float Health;
    public GameManager Manager;
    void Update()
    {
        if (Health<=0)
        {
            Manager.GameOver();
        }
    }
}
