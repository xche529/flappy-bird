using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zhongfen;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            int yesOrno = Random.Range(0, 10);
            if (yesOrno > 2) {
                spawnzhongfen();
            }
            timer = 0;
        }

    }
    void spawnzhongfen()
    {
        Instantiate(zhongfen, transform.position, transform.rotation);
    }
}
