using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zhongfenMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;
    int yrange = 8;
    int ydirection = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed + Vector3.up * moveSpeed * ydirection) * Time.deltaTime; 
        if (transform.position.y >= yrange) {
            ydirection = -1;
        }
        else if(transform.position.y <= -yrange) 
        {
            ydirection = 1;

        }

        if (transform.position.x < deadZone)
        {

            Destroy(gameObject);
        }
    }
}
