using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject UIHint;
    public GameObject cover;
    public GameObject Vault;
    public GameObject Reward;
    public GameObject[] Spawners;
    public GameObject levelPortal;

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
            UIHint.SetActive(false);
        }
        if (Deathcount == DeathLimits)
        {
            UIHint.SetActive(true);
            spawnersActive = false;
            DesactivateSpawner();
            Deathcount = 0;
            TaskComplete = true;
            levelPortal.SetActive(true);
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
        if (other.CompareTag("Player"))
        {
            cover.SetActive(false);
        }

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == false)
        {
            spawnersActive = true;
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && TaskComplete == true)
        {
            Destroy(Vault);
            UIHint.SetActive(false);
            Instantiate(Reward,this.transform.position,this.transform.rotation);
        }
    }
      private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            cover.SetActive(true);
        }
    }
}
