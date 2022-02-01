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
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private Rigidbody2D rb;
    public float speed = 6f;
   
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

        float xDirection = Input.GetAxisRaw("Horizontal");  /* Movement Inputs */
        float yDirection = Input.GetAxisRaw("Vertical");    

        /* Walk Input */
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 3f;


        }
        else
        {
            speed = 6f;

            anim.SetFloat("Speed", Mathf.Abs(xDirection));
            rb.velocity = new Vector2(speed * xDirection, rb.velocity.y);
        }

        if (speed == 3f)
        {
            anim.SetBool("Walk", true);
            rb.velocity = new Vector2(speed * xDirection, rb.velocity.y);

        }
        else { anim.SetBool("Walk", false); }

        /*----------Jump ---------*/
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {


          
            rb.velocity = Vector2.up * jumpforce;
            anim.SetBool("jump", true);

        }
      
        /*To Flip the Spirte in the Direction*/
       if (xDirection < 0)
        {
            sr.flipX = true;
        }
        else if (xDirection > 0)
        {
            sr.flipX = false;
        
        }
      
       /*------ Crouch ------*/
        if (Input.GetKey(KeyCode.LeftControl))
            {
            anim.SetBool("Crouch",true);
            sr.sprite = crouch;
            boxCollider2D.size = crouchingsize;
        
        
            }


       
        
    }
    /*-------Method To check if player is on Ground------*/
    private bool IsGrounded()
    {
        float extraheight = 1f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center , boxCollider2D.bounds.size,0f,Vector2.down , extraheight , platformLayerMask);
        return raycastHit2D.collider != null;
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

   /*private void Stopwalk()
    
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Walk", false);
        
        
        }
        
    
    
    }*/



}
