using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;
    GameController m_gc;

    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {

        m_rb.velocity = Vector2.up * speed;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_gc.ScoreInCrement();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("Trung");
        }
        else if (collision.CompareTag("SceneTopLimit"))
        {
            Destroy(gameObject);
        }
    }
}
