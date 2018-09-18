using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoint : MonoBehaviour
{
    public GameObject aerolite; //陨石预制体  
    float value_Y; //自身Y轴坐标
    void Start()
    {
        InvokeRepeating("Create", 0, 1);
        value_Y = transform.position.y; 
    }
    void Update()
    {
        //随着时间升高位置,这样生成的武器落下时才有更高加速度
        value_Y += Time.deltaTime;        
        transform.position = new Vector3(0, value_Y, 0);
    }
    void Create()
    {
        //自身位置生成陨石
        GameObject weapon = Instantiate(aerolite, transform.position, Quaternion.identity);
    }
}
