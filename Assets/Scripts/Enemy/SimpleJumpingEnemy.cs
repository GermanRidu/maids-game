using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJumpingEnemy : MonoBehaviour
{
    public float moveSpeed;
    private int damage = 1;
    public PlayerHealth playerHealth;
    Rigidbody2D rdb;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if(timer > 2){
            rdb.velocity = new Vector2(0, 5f);
        }

        if(IsFacingRight()) {
            rdb.velocity = new Vector2(moveSpeed, rdb.velocity.y);
        } else {
            rdb.velocity = new Vector2(-moveSpeed,rdb.velocity.y);
        }
        
        if(timer > 3){
            rdb.velocity = new Vector2(0, 0f);
            timer = 0;
        }

        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            playerHealth.TakeDamage(damage);
            transform.localScale = new Vector2(-(Mathf.Sign(rdb.velocity.x)), transform.localScale.y);
        }
    }

}
