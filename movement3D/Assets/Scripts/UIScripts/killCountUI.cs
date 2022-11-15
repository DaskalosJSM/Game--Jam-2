using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class killCountUI : MonoBehaviour
{
    public float killCount = 0;
    [SerializeField] TextMeshProUGUI killNumberText;
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        killCount = spawnManager.Deathcount;
        killNumberText.text = killCount.ToString("0");
    }
}
