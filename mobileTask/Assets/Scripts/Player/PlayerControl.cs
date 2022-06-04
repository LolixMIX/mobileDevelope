using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Entity
{

    public float Speed;
    public float HealthPoints;
    public float MaxHealth = 10;

    public Joystick Joystick;

    public float JumpForce;
    public int JumpValue = 1;
    private int _extraJump;
    private float _moveInput;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private new Collider2D collider2D;

    private bool _facingRight = true;
    public Transform GroundCheck;
    public float CheckRadius;
    public bool IsGrounded = false;

    private int playerLayer, platformLayer;
    public bool Key;
    public Animator Animator;

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, CheckRadius);
        IsGrounded = colliders.Length > 1;

    }
    void Run()
    {
        _moveInput = Joystick.Horizontal;
        rb.velocity = new Vector2(_moveInput * Speed, rb.velocity.y);

    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }
    public void JumpOnButton()
    {
        _extraJump--;

        if (_extraJump > 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, JumpForce);

            

        }
        else if (IsGrounded && _extraJump == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }


    }
    void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public override void GetDamage(float damage)
    {
        HealthPoints -= damage;

        Debug.Log(((int)HealthPoints));
        if (HealthPoints <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator JumpOff()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, CheckRadius);

        if (colliders.Length > 1 && colliders[1].CompareTag("Platform"))
        {
            Debug.Log(colliders[1].name);
            Physics2D.IgnoreCollision(collider2D, colliders[1]);
            yield return new WaitForSeconds(0.5f);
            Physics2D.IgnoreCollision(collider2D, colliders[1], false);
        }




    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            Key = true;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }
    private void Start()
    {
        _extraJump = JumpValue;
        playerLayer = LayerMask.NameToLayer("Player");
        platformLayer = LayerMask.NameToLayer("Platform");
        collider2D = GetComponent<Collider2D>();
        Key = false;
       // transform.position = new Vector2(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"));
    }


    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {

        Run();

        if (_facingRight == false && Joystick.Horizontal > 0)
        {
            Flip();
        }
        if (_facingRight == true && Joystick.Horizontal < 0)
        {
            Flip();
        }
        if (IsGrounded == true)
        {
            _extraJump = JumpValue;
        }
        //if (Input.GetButtonDown("Jump") && _extraJump > 0)
        //{

        //    Jump();
        //    _extraJump--;

        //}
        //else if (Input.GetButtonDown("Jump") && IsGrounded && _extraJump == 0)
        //{
        //    Jump();
        //}

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("������ {S}");
            StartCoroutine(JumpOff());
        }

        if (IsGrounded)
        {
            Animator.SetBool("Jumping", false);
        }
        else
        {
            Animator.SetBool("Jumping", true);
        }

        Animator.SetFloat("HorizontalMove", Mathf.Abs(Joystick.Horizontal));





    }

}
