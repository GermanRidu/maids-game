using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public GameObject follow;
    public Vector2 minPos, maxPos;
    public float smoothTime;

    private Vector2 veloity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, follow.transform.position.x, ref veloity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, follow.transform.position.y, ref veloity.y, smoothTime);

        transform.position = new Vector3(
         Mathf.Clamp(posX, minPos.x, maxPos.x), 
         Mathf.Clamp(posY, minPos.y, maxPos.y),  
         transform.position.z);
    }
}
