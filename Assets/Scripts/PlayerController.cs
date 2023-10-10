using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public float timer = 60f;
    public Text timerText;
    public Text lossText;
    public Text winText;

    public Button restartButton;
    public Button menuButton;

    private Rigidbody rbPlayer;

    public GameObject obstacle;
    private float delay = 0.2f;

    private bool gameOn = true;

    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);

        lossText.text = "";
        winText.text = "";

        rbPlayer = gameObject.GetComponent<Rigidbody>();

        InvokeRepeating("Spawn", delay, delay);
    }

    void Spawn()
    {
        float posX = Mathf.Round(Random.Range(-10, 10));
        float posZ = Mathf.Round(Random.Range(-10, 10));
        Instantiate(obstacle, new Vector3(posX, 10, posZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1f, 0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1f, 0f, 0f);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0f, 0f, 1f);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                transform.position += new Vector3(0f, 0f, -1f);
            }
            if (transform.position.x > 10)
            {
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
            }
            if (transform.position.x < -10)
            {
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }
            if (transform.position.z > 10)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            }
            if (transform.position.z < -10)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }
        }

        if (transform.position.y < 0)
        {
            gameOn = false;
            lossText.text = "You Fell Down, Try Again";
            winText.text = "";

            rbPlayer.useGravity = false;
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
        if (gameOn)
        {
            timer -= 1 * Time.deltaTime;
            timerText.text = "Timer: " + timer.ToString("0");
            if (timer <= 0)
            {
                timer = 0;
                winText.text = "You Win, Want to Try Again?";
                lossText.text = "";
                restartButton.gameObject.SetActive(true);
                menuButton.gameObject.SetActive(true);
            }
        } else
        {
            timerText.text = "Timer: " + timer.ToString("0");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOn = false;
            lossText.text = "You Got Squashed, Try Again";
            restartButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("ApricotStart");
    }

    public void OnMenuButtonPress()
    {
        SceneManager.LoadScene("ApricotMenu");
    }
}
