using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    public bool goingUp;
    public bool sway;
    public float speed;
    [SerializeField] float zigZagSpeed = 3f;
    [SerializeField] float zigZagWidth = 500f;
    private float timer;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (goingUp == false)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (transform.position.y >= gameManager.verticalScreenSize * 1.25f || transform.position.y <= -gameManager.verticalScreenSize * 1.25f)
        {
            Destroy(this.gameObject);
        }
        if (sway)
        {
            timer += Time.deltaTime * zigZagSpeed;
            float sideStep = Mathf.Sin(timer) * (zigZagWidth * 2) * Time.deltaTime;

            transform.Translate(new Vector3(sideStep, -speed, 0) * Time.deltaTime * 3f);

            if (transform.position.y < -6.5f)
            {
                Destroy(this.gameObject);
            }

            // ensures that enemies with zigzag stay on screen
            if (transform.position.x > 8.5)
            {
                transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 3f);
            }
            if (transform.position.x < -8.5)
            {
                transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 3f);
            }
        }
        
    }
}
