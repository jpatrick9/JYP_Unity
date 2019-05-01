using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    public GameObject[] candies = new GameObject[4];
    public float spawnInterval = 1.0f;

    public static CandySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, candies.Length);
        Vector3 randXY = new Vector3 (Random.Range(-7.5f, 7.5f), Random.Range(1.5f, 7.5f), .1f);
        Instantiate(candies[rand], randXY, Quaternion.identity) ;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(.3f);

        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
          
    }

    public void StartSpawn()
    {
        StartCoroutine("Spawn");
    }

    public void StopSpawn()
    {
        StopCoroutine("Spawn");
    }




}
