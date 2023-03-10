using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumph = 5;
    private Rigidbody2D rb;
    public bool isGrounded = false;

    private Vector3 rotation;
    private Animator anim;

    private CoinManager m;

    public GameObject panel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
        m = GameObject.FindGameObjectWithTag("Text").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = UnityEngine.Input.GetAxis("Horizontal");

        if(richtung != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning",false);
        }
        if ( richtung < 0) 
        {
            transform.eulerAngles = rotation - new Vector3(0, 180, 0);
            transform.Translate(Vector2.right * speed * -richtung * Time.deltaTime);
        }
        if (richtung > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }

        if(isGrounded == false)
        {
            anim.SetBool("IsJumping", true);
        }else
        {
            anim.SetBool("IsJumping", false);
        }



        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin");
        {
            m.Addmoney();
            Destroy(other.gameObject);
            
        }
        if (other.gameObject.tag == "Spike") 
        {
            panel.SetActive(true);
            Destroy(gameObject);
        }
    }

}
