using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource niganma;
    public AudioSource amagi;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            niganma.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        myRigidbody.transform.Rotate(new Vector3(0, 0, -1));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        amagi.Play();
        logic.gameOver();
        birdIsAlive= false;
    }
}
