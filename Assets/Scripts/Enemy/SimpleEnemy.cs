using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    public float moveSpeed;
    private int damage = 1;
    public PlayerHealth playerHealth;
    Rigidbody2D rdb;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(IsFacingRight()) {
            rdb.velocity = new Vector2(moveSpeed, 0f);
        } else {
            rdb.velocity = new Vector2(-moveSpeed, 0f);
        }
        
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    { 
        transform.localScale = new Vector2(-(Mathf.Sign(rdb.velocity.x)), transform.localScale.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            playerHealth.TakeDamage(damage);
            transform.localScale = new Vector2(-(Mathf.Sign(rdb.velocity.x)), transform.localScale.y);
        }
    }

}
