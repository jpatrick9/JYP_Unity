using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject target;
    int score = 0;
    public Text scoreText;
    bool win = false;
    public GameObject winText;

    public AudioSource[] winSound = new AudioSource[2];
    

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        if (win == true)
        {
            CancelInvoke("Spawn");
        }

        if (Input.GetMouseButtonDown(0))
        {
            //GetComponent<AudioSource>().Play();
            winSound[0].Play();
        }

	}

    void Spawn()
    {
        float randomX;
        float randomY;

        randomX = Random.Range(-17f, 17f);
        randomY = Random.Range(-9.5f, 9.5f);

        Vector3 randomPosition = new Vector3(randomX, randomY, 0);

        Instantiate(target, randomPosition, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        print(score);
        scoreText.text = score.ToString();

        if (score >= 5)
        {
            win = true;
            winText.SetActive(true);
            winSound[1].Play();
        }
    }

}
