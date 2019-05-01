using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform, diamond;
    Vector3 lastPos;
    float size;
    public bool gameOver = false;
    public PlatformSpawner instance;
    public BallController bc;
    

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

        bc = GameObject.Find("Ball").GetComponent<BallController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = bc.GetComponent<BallController>().gameOver;
        if (gameOver == true)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 1f, .2f);
    }

    void SpawnPlatforms()
    {
        if (gameOver == true)
        {
            return;
        }

        int rand = Random.Range(0, 6);
        if(rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;

        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x,pos.y + 1, pos.z), diamond.transform.localRotation);
        }

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;

        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.localRotation);
        }
    }

}
