using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Vault;
    public GameObject Reward;
    public GameObject[] Spawners;
    public float Deathcount;
    [SerializeField] int Index;
    [SerializeField] float DeathLimits;
    [SerializeField] float ActivationInterval = 5;
    [SerializeField] float ActivationMemory;
    [SerializeField] bool spawnersActive;
    [SerializeField] bool TaskComplete;
    void Start()
    {
        ActivationMemory = ActivationInterval;
    }
    void Update()
    {
        ActivationInterval -= 1 * Time.deltaTime;
        if (Deathcount <= DeathLimits && spawnersActive == true && ActivationInterval <= 0)
        {
            ActivateSpawner();
            ActivationInterval = ActivationMemory;
        }
        if (Deathcount >= DeathLimits)
        {
            spawnersActive = false;
            DesactivateSpawner();
            Deathcount = 0;
            TaskComplete = true;
        }
    }
    void DesactivateSpawner()
    {
        Index = Random.Range(0, Spawners.Length);
        Spawners[Index].SetActive(false);
    }
    void ActivateSpawner()
    {
        Index = Random.Range(0, Spawners.Length);
        Spawners[Index].SetActive(true);
    }
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == false)
        {
            spawnersActive = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == true)
        {
            Destroy(Vault);
            Instantiate(Reward,this.transform.position,this.transform.rotation);
        }
    }
}
