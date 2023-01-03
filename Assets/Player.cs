using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumph = 5;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private Vector3 rotation;
    // Start is called before the first frame update

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rotation = transform.eulerAngles;
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
            transform.Translate(Vector2.left * speed * richtung * Time.deltaTime);
        }
        if (richtung > 0)
        {
            transform.eulerAngles = rotation;
            transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);
        }



        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumph, ForceMode2D.Impulse);
        }

        
    }
    private void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

}
