using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sr;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 5f;
    public float jumpforce = 5f;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        float xDirection = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed",Mathf.Abs(xDirection));
        //rb.velocity = transform.position(speed * xDirection, rb.velocity.y);

        if (xDirection < 0)
        {
            sr.flipX = true;
        }
        else if (xDirection > 0)
        {
            sr.flipX = false;
        
        }
        
    }
}
