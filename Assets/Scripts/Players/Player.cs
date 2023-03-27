using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rdb;

    // Start is called before the first frame update
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxisRar detiene el movimiento sin deslizarse 
        float dirX = Input.GetAxis("Horizontal");
        rdb.velocity = new Vector2(dirX * 7f, rdb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rdb.velocity = new Vector2(0, 14f);
        }
    }
}
