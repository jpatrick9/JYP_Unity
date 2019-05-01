using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public bool gameBegan = false, gameOver = false;
    public Rigidbody rb;
    public GameObject ps;
    public GameObject StartButton, GameOverPanel;
    public PlatformSpawner plats;
    public int score, highScore;
    public Text highScoreText, scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        plats = GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector3(speed,0,0);
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = highScore.ToString();
        score = 0;
        
        gameBegan = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameBegan)
        {            
            if (Input.GetButtonDown("Fire1"))
            {
                highScoreText.gameObject.SetActive(false);
                scoreText.gameObject.SetActive(true);

                plats.instance.StartSpawningPlatforms();
                Destroy(StartButton);
                rb.velocity = new Vector3(speed, 0, 0);
                gameBegan = true;
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1.0f))
        {
            gameOver = true;
            

            //rb.velocity = Vector3.down * 25.0f;
            //OR
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameOverPanel.gameObject.SetActive(true);

            int checkScore = score;
            if(highScore < checkScore)
            {
                highScore = checkScore;
                PlayerPrefs.SetInt("highScore", score);

            }
        }

        if (Input.GetButtonDown("Fire1") && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {

            //we want to be able to destroy the particle system after it is done playing, as a form of garbage collection. therefore, instead of
            //Instantiate(ps, col.gameObject.transform.position, Quaternion.identity);
            //we use
            GameObject particleSys = Instantiate(ps, col.gameObject.transform.position, Quaternion.identity) as GameObject;

            Destroy(col.gameObject);
            Destroy(particleSys, 1f);

            score += 1;
            scoreText.text = score.ToString();
            
            //if the instantiate funciton was called AFTER we destroyed the diamond (col), it wouldn't have a position to reference.
            //Instantiate(ps, col.gameObject.transform.position, Quaternion.identity);
        }
    }
}
