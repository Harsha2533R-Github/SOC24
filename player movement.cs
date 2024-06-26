using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float speed;
    private float move;

    public float jump;

    public bool isJumping;

    private Rigidbody2D rb;

   /* public class RollAndMove : MonoBehaviour
    {
        public float moveForce = 5f;
        public float torqueForce = 5f;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            // Apply a forward force to move the ball
            rb.AddForce(transform.forward * moveForce);

            // Apply torque to rotate the ball
            rb.AddTorque(transform.right * torqueForce);
        }
    }
   */

     
    

      public class RollAndMove : MonoBehaviour
      {
          [SerializeField] private float moveForce = 5f; // Editable in Inspector
          [SerializeField] private float torqueForce = 5f; // Editable in Inspector
         private Rigidbody rb;

         void Start()
         {
        rb = GetComponent<Rigidbody>();
         }

          void FixedUpdate()
          {
               // Apply a forward force to move the ball
            rb.AddForce(transform.forward * moveForce);

               // Apply torque to rotate the ball
             rb.AddTorque(transform.right * torqueForce);
          }
      }



// Start is called before the first frame update
void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
           rb.AddForce( new Vector2(rb.velocity.x, jump));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
        
    }
}
