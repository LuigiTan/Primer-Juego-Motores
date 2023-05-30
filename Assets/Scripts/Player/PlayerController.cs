using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public new Rigidbody2D rigidbody;
    public float jumpVelocity;
    public float moveVelocity;
    public float gravityVelocity;
    public Transform origin;
    public float radius;

    private Vector2 velocity;
    private bool grounded;
    private bool jumping;

    private void Update()
    {
        float move = ControlsInstance.Instance.GamePlay.Move.ReadValue<float>();
        animator.SetBool("Walking", move != 0);

        Vector3 scale = Vector3.one;
        if (move < 0)
        {
            scale.x = 1;
        }
        else if (move > 0)
        {
            scale.x = -1;
        }
        transform.localScale = scale;

        //if (!grounded) velocity.y -= gravityVelocity * Time.deltaTime;
        //else velocity.y = -gravityVelocity;



        // Se esta asignando -1 cuando salta porque el trigger aún no indica que sale del piso
        grounded = IsGrounded();
        velocity.y = grounded && !jumping ? -1: velocity.y - gravityVelocity * Time.deltaTime;
        if (ControlsInstance.Instance.GamePlay.Jump.WasPressedThisFrame()&& grounded)
        {
            velocity.y = jumpVelocity;
            StartCoroutine(JumpingHandler());
            //jumping = true;
        }
        velocity.x = move * moveVelocity;
        rigidbody.velocity = velocity;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(origin.position, radius);
    }

    private IEnumerator JumpingHandler()
    {
        jumping = true;
        yield return new WaitForSeconds(0.5f);
        jumping = false;

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    grounded = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    grounded = false;
    //    jumping = false;
    //}
}
