using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumph = 5;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float richtung = UnityEngine.Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * richtung * Time.deltaTime);

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
