using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//这个是道具生成器，工作原理和kunkun柱子生成器差不多
public class PropSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    //添加中分道具object，你们要写道具的话都要在这里加
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
            //随机生成一到十的数根据概率生成道具
            //不同的道具必须用不同的range否则会同时生成两个
            int yesOrno = Random.Range(0, 10);
            //中分的range是8到10
            if (yesOrno > 8) {
                spawnzhongfen();
            }
            timer = 0;
        }

    }
    //生成中分的代码
    void spawnzhongfen()
    {
        Instantiate(zhongfen, transform.position, transform.rotation);
    }
}
