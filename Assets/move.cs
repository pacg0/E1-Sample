using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    //[SerializeField] private InputAction mov;
    private Vector2 value;
    private Animator animator;
    private Rigidbody2D rb;
    private bool ground;
    private float speed = 8;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * value.x, rb.velocity.y);
    }
    void OnMove(InputValue val)
    {
        value = val.Get<Vector2>();
        animator.SetBool("right", !Mathf.Approximately(value.x, 0));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = false;
        }
    }
    void OnJump(InputValue val)
    {
        if (ground)
        {
            rb.AddForce(new Vector2(0, 350));
        }
    }
}
