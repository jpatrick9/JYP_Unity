using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public float yBound = -6.0f;
    public GameManager inst;

    // Start is called before the first frame update
    void Start()
    {
        inst = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= yBound)
        {
            GameManager.instance.DecrementLives();
            Destroy(gameObject);
        }
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            GameManager.instance.IncrementScore();
            //inst.IncrementScore();
            Destroy(gameObject);
        }
    }
}
