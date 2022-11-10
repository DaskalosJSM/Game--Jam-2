using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] EnemiesPrefabs;
    private float spawnIntervalMemory;
    private float lifeTimeMemory;
    [SerializeField] float spawnInterval;
    [SerializeField] float lifeTime = 20;

    private void Start()
    {
        lifeTimeMemory = lifeTime;
        spawnIntervalMemory = spawnInterval;
    }
    private void Update()
    {
        spawnInterval -= 1 * Time.deltaTime;
        lifeTime -= 1 * Time.deltaTime;

        if (spawnInterval <= 0)
        {
            Invoke("SpawningEnemies",1);
            spawnInterval = spawnIntervalMemory;
        }
        

        if (lifeTime <= 0)
        {
            this.gameObject.SetActive(false);
            lifeTime = lifeTimeMemory;
        }
    }
    void SpawningEnemies()
    {
        Vector3 SpawnPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        int EnemiesIndex = Random.Range(0, EnemiesPrefabs.Length);
        Instantiate(EnemiesPrefabs[EnemiesIndex], SpawnPos, EnemiesPrefabs[EnemiesIndex].transform.rotation);
    }
}
