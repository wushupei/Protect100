using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour //物品管理类,不用挂
{
    public ObjectPool op; //声明对象池脚本
    void OnEnable()
    {
        op = FindObjectOfType<ObjectPool>();    
    }
    void Update()
    {
        if (transform.position.y < -20) //如果物体低于一定位置 
        {
            PutInPools(); //存入对象池
            gameObject.SetActive(false);
        }
    }
    public virtual void PutInPools() { }  //定义存入对象池的虚方法
}
