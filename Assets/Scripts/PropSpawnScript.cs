using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����ǵ���������������ԭ���kunkun�������������
public class PropSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    //����зֵ���object������Ҫд���ߵĻ���Ҫ�������
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
            //�������һ��ʮ�������ݸ������ɵ���
            //��ͬ�ĵ��߱����ò�ͬ��range�����ͬʱ��������
            int yesOrno = Random.Range(0, 10);
            //�зֵ�range��8��10
            if (yesOrno > 8) {
                spawnzhongfen();
            }
            timer = 0;
        }

    }
    //�����зֵĴ���
    void spawnzhongfen()
    {
        Instantiate(zhongfen, transform.position, transform.rotation);
    }
}
