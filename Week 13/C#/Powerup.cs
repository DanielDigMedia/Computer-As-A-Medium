using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] float downwardSpeed = 1f;

    void Update()
    {
        transform.Translate(new Vector3(0, -downwardSpeed, 0) * Time.deltaTime * 3f);

        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
