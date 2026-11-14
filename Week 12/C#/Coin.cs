using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    [SerializeField] float downwardSpeed = 1f;
    [SerializeField] private string targetTag = "Player";

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            GameManager.AddPoint();
            Destroy(this.gameObject);
        }
    }
}
