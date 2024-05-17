using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public GameObject bullet;
    public Transform shootingPoint;
    GameController controller;
    public AudioSource audioSource;
    public AudioClip shootingSound;
    
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GameOver() == true)
        {
            return;
        }
        float xDir = Input.GetAxisRaw("Horizontal");

        if((xDir < 0 && transform.position.x <= -7.5) || (xDir > 0 && transform.position.x >= 7.5))
        {
            return;
        }

        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            Shoot(); 
        }


    }

    public void Shoot()
    {
        if( bullet && shootingPoint != null)
        {
            if(audioSource && shootingSound != null) 
            {
                audioSource.PlayOneShot(shootingSound);
            }
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            controller.SetGameOverState(true);
            Destroy(collision.gameObject);
            Debug.Log("Over");
        }
    }
}
