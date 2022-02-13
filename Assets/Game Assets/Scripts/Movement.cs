using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Animator anim; // Animator Variable
    private SpriteRenderer sr;  // Spriterender VAriable
    public Sprite Standing; // Crouch Standing Sprite
    public Sprite crouch; // Crouch Crouched Sprite
    public BoxCollider2D boxCollider2D; // BoxCollider Reference
    public Vector2 StandingSize; // VEctor Size of Collider of standing pos.
    public Vector2 crouchingsize; // VEctor Size of Collider of Crouching pos.
    private BoxCollider2D coll; // Collider refrence 
    [SerializeField] private LayerMask platformLayerMask; // Ground LAyer Mask
    [SerializeField] private Rigidbody2D rb; // Rigidbody Refrence
    [SerializeField] private float speed = 6f; // Speed Variable
    bool CanDoubleJump; // Double JUmp bool 
    [SerializeField] private float jumpforce = 5f; // Jummpforce VAriable
   


void Start()
    { 
        // Refrences :-
        boxCollider2D = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StandingSize = boxCollider2D.size;
        
    
}

    
    void Update()
    {

        if (transform.position.y < -2.5)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
        float xDirection = Input.GetAxisRaw("Horizontal");  /* Movement Inputs */ // Horizontal Way
        float yDirection = Input.GetAxisRaw("Vertical"); // VErtical Movment Inputs

        /* Walk Input */
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            speed = 3f;



        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 6f;
            anim.SetBool("Walk", false);
        
        
        }
        else
        {
            speed = 6f;

            if (IsGrounded())
            {
                anim.SetFloat("Speed", Mathf.Abs(xDirection));
                rb.velocity = new Vector2(speed * xDirection, rb.velocity.y);
            }
           
        }

        if (speed == 3f)
        {
            anim.SetBool("Walk", true);
            rb.velocity = new Vector2(speed * xDirection, rb.velocity.y);
           
        }
        // else { anim.SetBool("Walk", false); }

        /*----------Jump ---------*/
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
            CanDoubleJump = true;

        }
        else if (CanDoubleJump)
        {
            Jump();
            CanDoubleJump = false;


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
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpforce;
        anim.SetBool("jump", true);


    }
  /* private void Stopwalk()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Walk", false);
        
        
        }
        
    
    
    }

    */

}
