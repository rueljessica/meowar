using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] Animator animator;


    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public bool onTheGround;


    // Start is called before the first frame update
    void Start() {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("attack3")) {
            direction = Input.GetAxis("Horizontal");
            if (direction > 0) {
                transform.localScale = facingRight;
            }
            if (direction < 0) {
                transform.localScale = facingLeft;
            }
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
    }
}
