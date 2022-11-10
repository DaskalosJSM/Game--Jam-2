using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPortal : MonoBehaviour
{
    public GameManager Manager;

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")){
            Manager.SetGameState(GameState.Level1);
        }
    }
}
