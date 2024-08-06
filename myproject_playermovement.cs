using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myproject_playermovement : MonoBehaviour
{
    public float speed;
    private float move;
    public float jump;
   // bool crouch = false;
    public bool isJumping = false;
    //public bool isCrouching = false;
    // public float crouchColliderHeight = 0.5f;
    //public GameObject standing_collider; // Reference to the standing collider
    //public GameObject crouching_collider; // Reference to the crouching collider
    private Rigidbody2D rb;
    bool isFacingRight = true;
    public Animator animator;
    //private int score = 0;
    public Text scoreTextCherry;
    public Text scoreTextMelon;
  
    

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        scoreTextCherry.text = scoring.TotalScoreCherry + " :";
        scoreTextMelon.text = scoring.TotalScoreMelon + " :";
       
    }


    // Update is called once per frame
    void Update()
    {

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            Debug.Log("Jump");
        }

        // Detect crouch input (you can change this to any key or button)
        //if (Input.GetKeyDown("Crouch"))
        //{
        //   ToggleCrouch();
        //}

        // Check for horizontal input
        if (move != 0)
        {
            // Flip the sprite based on movement direction
            if ((move < 0 && isFacingRight) || (move > 0 && !isFacingRight))
            {
                FlipSprite();
            }

        }

        animator.SetBool("Running", Mathf.Abs(move) > 0.1f);

    }



  /* void ToggleCrouch()
    {
        isCrouching = !isCrouching;
        animator.SetBool("IsCrouching", isCrouching);

        // Adjust collider height when crouching
        //  var collider = GetComponent<Collider>();
        //   if (collider != null)
        //  {
        //     collider.height = isCrouching ? crouchColliderHeight : originalColliderHeight;
        //  } 
        

        standing_collider.SetActive(!isCrouching);
        crouching_collider.SetActive(isCrouching);

    }
    */


    private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
                animator.SetBool("Jumping", isJumping);
            }

        if (other.gameObject.CompareTag("Cherry"))
        {
            scoring.TotalScoreCherry += 1;
            scoreTextCherry.text = scoring.TotalScoreCherry + " :";
            // score += 1;
            // Debug.Log(score);
            other.gameObject.SetActive(false);
            
        }

        if (other.gameObject.CompareTag("Melon"))
        {
            scoring.TotalScoreMelon += 1;
            scoreTextMelon.text = scoring.TotalScoreMelon + " :";
            other.gameObject.SetActive(false);
        }
    }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = true;
                animator.SetBool("Jumping", isJumping); }

        }

    

        void FlipSprite()
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            score += 1;
            Debug.Log(score);
            collision.gameObject.SetActive(false);
        }
    } 
   */
}