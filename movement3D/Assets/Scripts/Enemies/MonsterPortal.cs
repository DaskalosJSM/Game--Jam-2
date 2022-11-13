using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPortal : MonoBehaviour
{
    public SpawnManager Spawner;
    public GameManager Manager;

    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Transport", 2.0f);
        }

    }
    void Transport()
    {
        Manager.SetGameState(GameState.Level1);

    }
}
