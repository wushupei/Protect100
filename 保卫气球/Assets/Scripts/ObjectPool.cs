using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    CreatePoint cp; //声明生成点脚本
    public Stack<GameObject>[] pools; //声明对象池数组
    public Stack<GameObject> levelText; //声明关卡字幕的对象池
    void Awake()
    {
        cp = FindObjectOfType<CreatePoint>(); 
        CreatePool();
        levelText = new Stack<GameObject>();
    }
    void CreatePool()
    {
        //根据生成点脚本里的武器预制体种类数创建相应数量的对象池
        pools = new Stack<GameObject>[cp.weapons.Count]; 
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new Stack<GameObject>();
        }
    }
}
