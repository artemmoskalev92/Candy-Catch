using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] float boundX;
    [SerializeField] float time;
    [SerializeField] float repeatSpawn;

    [SerializeField] GameObject[] Candies;

    public static CandySpawner Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        //InvokeRepeating("SpawnCandy", time, repeatSpawn);
        StartSpawningCandies();
    }

   
    void Update()
    {
        
    }
    void SpawnCandy()
    {
        int randomCandy = Random.Range(0, Candies.Length);
        float randomPos = Random.Range(-boundX, boundX);
        Vector3 randomXPos = new Vector3(randomPos, transform.position.y, transform.position.z);

        Instantiate(Candies[randomCandy], randomXPos, Quaternion.identity);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(time);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(repeatSpawn);
        }
    }
    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }
    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
