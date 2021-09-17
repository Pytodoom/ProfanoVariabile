using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float JumpForce;
    private float moveInput;

    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private Transform feetPos;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask whatIsGound;

    [SerializeField]
    private float jumpTimeCounter;
    [SerializeField]
    private float jumpTime;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //assegno il rigidbody a rb
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); //se premo WASD mi muovo.
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGound); //faccio un check. Se effettivamente feetPos sta toccando uno sprite con layer Ground

        if (moveInput > 0) //faccio flippare lo sprite.. se mi muovo verso destra gira verso destra e viceversa.
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(isGrounded == true && Input.GetKeyDown(KeyCode.J)) //se premo J il player salta
        {
            isJumping = true; //se sono Ground e premo il salto. Allora attivo il salto e dò il valore di JumpTime a JumpTimeCounter
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * JumpForce; //assegno a rb.velocity la direzione verso l'alto + la forza.
        }

        if (Input.GetKey(KeyCode.J) && isJumping == true) //salta all'infinito
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * JumpForce*1.5f; //assegno a rb.velocity la direzione verso l'alto + la forza.
                jumpTimeCounter -= Time.deltaTime; //diminuisco JumpTimeCounter
            }
            else
            {
                isJumping = false; //se JumpTimeCounter è minore di 0 allora disattivo il salto
            }
        }

        if (Input.GetKeyUp(KeyCode.J)) 
        {
            isJumping = false; //disattivo il salto premendo J
        }
    }
}
