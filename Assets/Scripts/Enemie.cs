using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class Enemie : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float distMin;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator animator;

    public Player playerHealth;
    private double damage = 0.5;


    void Update() {
        Vector2 playerPosition = this.player.position;
        Vector2 actualPosition = this.transform.position;

        float dist = Vector2.Distance(actualPosition, playerPosition);
        if (dist >= this.distMin)
        {
            Vector2 direction = playerPosition - actualPosition;
            direction = direction.normalized;

            this.rb.velocity = (this.speed * direction);

            if (this.rb.velocity.x > 0)
            {
                this.sr.flipX = false;
            }
            else if (this.rb.velocity.x < 0)
            {
                this.sr.flipX = true;
            }
        }
        else
        {
            this.rb.velocity = Vector2.zero;
        }
    }

   

    [SerializeField] private int maxHelth = 150;
    double currentHelth;


    // Start is called before the first frame update
    void Start(){
        currentHelth = maxHelth;
    }

    

    public void takeDamage(double damage) {
        currentHelth -= damage;

        if(currentHelth <= 0) {
            die();
        }
    }


    void die() {
        Debug.Log("Enemie is dead");

        animator.SetTrigger("dead");

        GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            animator.SetTrigger("attack");
            playerHealth.takeDamage(damage);
        }
    }
}
