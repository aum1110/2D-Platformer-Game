using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    private SpriteRenderer sr;
    public Sprite Standing;
    public Sprite crouch;
    public BoxCollider2D boxCollider2D;
    public Vector2 StandingSize;
    public Vector2 crouchingsize;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableground;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 5f;
   
    public float jumpforce = 5f;
   


void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StandingSize = boxCollider2D.size;
        
    
}

    
    void Update()
    {

        float xDirection = Input.GetAxisRaw("Horizontal");
        float yDirection = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Speed",Mathf.Abs(xDirection));
        
        rb.velocity = new Vector2(speed * xDirection, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {


            Debug.Log("Jump"); 
            rb.velocity = Vector2.up * jumpforce;
            anim.SetBool("jump", true);

        }
      

       if (xDirection < 0)
        {
            sr.flipX = true;
        }
        else if (xDirection > 0)
        {
            sr.flipX = false;
        
        }
      

        if (Input.GetKey(KeyCode.LeftControl))
            {
            anim.SetBool("Crouch",true);
            sr.sprite = crouch;
            boxCollider2D.size = crouchingsize;
        
        
            }


       
        
    }

    private void Nojump()
        {

        anim.SetBool("jump", false);
        }

    private void Nocrouch()
    {

        anim.SetBool("Crouch", false);
        sr.sprite = Standing;
        boxCollider2D.size = StandingSize;

    }



}
