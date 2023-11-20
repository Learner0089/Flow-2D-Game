using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private BoxCollider2D coll;
   private SpriteRenderer sprite;//helps in change the directions from left to right on moving
   private Animator anim;//to set up animation on moving
    private float dirX;
    [SerializeField] private LayerMask jumpableGround;
   [SerializeField] private float moveSpeed = 7f;//SerializeField helps in changing the created values directly in unity
   [SerializeField] private float JumpForce = 14f;
   private enum MovementState{Idle,Running,Jumping,Falling }//enum contains different states
   [SerializeField] private AudioSource JumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite =GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
   private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")&&(IsGrounded())){
            JumpSoundEffect.Play();
            rb.velocity =new Vector2(rb.velocity.x,JumpForce);
        }
        UpdateAnimation();
    }
    private void UpdateAnimation(){
        MovementState state;
         if(dirX>0f){
            state = MovementState.Running;
            sprite.flipX = false;//flip is used to change the directions from left to right on moving
        }
        else if(dirX<0f){
            state = MovementState.Running;
            sprite.flipX = true;
        }
        else{
            state = MovementState.Idle;
        }
        if(rb.velocity.y> 0.1f)//jumping is mentioned below as jump has high priority (so not putting else if)
        {
            state = MovementState.Jumping;
        }
        else if(rb.velocity.y < -0.1f){
            state = MovementState.Falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size, 0f,Vector2.down, 0.1f,jumpableGround);
    /*helps in creating a box around edit collider that helps to check that player can only jump if it hits ground 
    and not from sidelines*/
    }
}
