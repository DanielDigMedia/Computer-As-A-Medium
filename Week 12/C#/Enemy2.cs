using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] float downwardSpeed = .6f;
    [SerializeField] float zigZagSpeed = 3f;
    [SerializeField] float zigZagWidth = 500f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float downStep = -downwardSpeed;
        timer += Time.deltaTime * zigZagSpeed;
        float sideStep = Mathf.Sin(timer) * (zigZagWidth * 2) * Time.deltaTime;

        transform.Translate(new Vector3(sideStep, downStep, 0) * Time.deltaTime * 3f);

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


