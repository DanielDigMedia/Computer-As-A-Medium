using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float downwardSpeed = 1f;
    private float timer;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -downwardSpeed, 0) * Time.deltaTime * 3f);

        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }

}


