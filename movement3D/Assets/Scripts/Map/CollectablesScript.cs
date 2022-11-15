using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    public PlayerStats Stats;
    public UIManager UIManager;
    [SerializeField] bool Life;
    
    [SerializeField] bool Anmo;
    
    [SerializeField] bool Keylvl2;
    [SerializeField] bool Keylvl3;
    [SerializeField] bool Keylvlboss;
    public soundManager soundManager;
    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<soundManager>();
        Stats = GameObject.Find("GameStatsManager").GetComponent<PlayerStats>();
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && Keylvl2 == true)
        {
            soundManager.Instance.Play(4);
            UIManager.indice = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 1;
        }
        if (other.gameObject.CompareTag("Player") && Keylvl3 == true)
        {
            soundManager.Instance.Play(4);
            UIManager.indice = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 2;
        }
        if (other.gameObject.CompareTag("Player") && Keylvlboss == true)
        {
            soundManager.Instance.Play(4);
            UIManager.indice = 1;
            Destroy(gameObject);
            Stats.weaponPiece = 3;
        }
        if (other.gameObject.CompareTag("Player") && Life == true && Stats.Health<100)
        {
            soundManager.Instance.Play(4);
            Destroy(gameObject);
            Stats.Health += 25;
            Life = false;
        }
         if (other.gameObject.CompareTag("Player") && Anmo == true)
        {
            Destroy(gameObject);
            Stats.Anmo += 5;
            Anmo = false;
        }
    }
}
