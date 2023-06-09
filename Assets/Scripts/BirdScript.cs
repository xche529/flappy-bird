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
    public float moveSpeed = 5;
    public int zhongfen = 0;
    public int iszhongfen2 = 0;
    public GameObject zhongfen2;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        //寻找logic script 赋值给logic
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //检测是否为中分状态
        if(zhongfen == 1)
        {
            float yvelocity = FindyVelocityZhongFen();
            myRigidbody.velocity = Vector2.up * yvelocity;
            //第一帧生成中分 
            if (iszhongfen2 == 0)
            {
                spawnZhongfen();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            niganma.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
    }
    //碰撞后死亡
    private void OnCollisionEnter2D(Collision2D collision)
    {
        amagi.Play();
        logic.gameOver();
        birdIsAlive= false;
    }
    //中分效果触发后计算篮球的y轴速度
    public float FindyVelocityZhongFen()
    {
        //寻找所有kun
        GameObject[] Kuns = GameObject.FindGameObjectsWithTag("KunKun");
        float xdistance = 1000;
        float ydistance = 0;
        //找到篮球右边的第一个kun
        foreach (GameObject Kun in Kuns) {
            if (Kun.transform.position.x - transform.position.x > 0 && xdistance > Kun.transform.position.x - transform.position.x)
            {
                xdistance = Kun.transform.position.x - transform.position.x;
                ydistance = transform.position.y - Kun.transform.position.y;
                
            }
        }
        //根据xy距离算出篮球的y速度
        return -ydistance / xdistance * moveSpeed;
    }
    //在篮球上显示中分效果
   public void spawnZhongfen()
    {
        //生成中分object
        GameObject childGameObject = Instantiate(zhongfen2, this.gameObject.transform, true);
        childGameObject.transform.position= transform.position + Vector3.up*2;
        iszhongfen2 = 1;
    }
}
