using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int lives;

    private GameManager gameManager;

    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 6f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lives = 3;
        gameManager.ChangeLivesText(lives);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    public void LoseALife()
    {
        //lives = lives - 1;
        //lives -= 1;
        lives--;
        gameManager.ChangeLivesText(lives);
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Shooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
        //Read the input from the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //Player leaves the screen horizontally
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        //Player cannot move above the middle of the screen
        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        //Player cannot move below the bottom of the screen
        else if (transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        }
    }
}
