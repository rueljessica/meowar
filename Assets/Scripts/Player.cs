using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private int extraJump = 0;
    [SerializeField] Animator animator;
    [SerializeField] private AudioSource collectSound;

    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public bool onTheGround;
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemieLayers;
    public int attackDamage = 20;

    public double health;
    public double maxHealth = 5;

    // Start is called before the first frame update
    void Start() {
        health = maxHealth;
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        onTheGround = Physics2D.OverlapCircle(groundDetector.position, 0.2f, whatIsGround);

        if (Input.GetButtonDown("Jump") && onTheGround == true) {
            rb.velocity = Vector2.up * 10;
            extraJump = 1;
            onTheGround = false;
        }
        else if (Input.GetButtonDown("Jump") && onTheGround == false && extraJump > 0) {
            rb.velocity = Vector2.up * 10;
            extraJump--;
        }
        
        if (onTheGround) {
            extraJump = 1;
        }

        if (onTheGround) {
            float velocityX = Mathf.Abs(this.rb.velocity.x);
          
        }
        else {
            float velocityY = this.rb.velocity.y;
            if (velocityY > 0) {
                this.animator.SetBool("jump", true);
            }
            else {
                this.animator.SetBool("jump", false);
            }
        }

        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            transform.localScale = facingRight;
        }
        if (direction < 0)
        {
            transform.localScale = facingLeft;
        }
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            attack2();
        }
    }

    void attack() {
        animator.SetTrigger("attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemieLayers);
        foreach(Collider2D enemie in hitEnemies) {
            enemie.GetComponent<Enemie>().takeDamage(attackDamage);
        }
    }

    void attack2() {
        animator.SetTrigger("attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemieLayers);
        foreach (Collider2D enemie in hitEnemies) {
            enemie.GetComponent<Enemie>().takeDamage(attackDamage*1.5);
        }
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void takeDamage(double val) {
        health -= val;
        if(health <= 0) {
            die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Coin")) {
            collectSound.Play();
            Destroy(collision.gameObject);
        }
    }

    public void die() {
        gameObject.SetActive(false);
        GameManager.Instance.GameOver();
    }
}
