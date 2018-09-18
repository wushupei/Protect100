using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ObjManager
{
    public int index; //自身预制件所在集合的索引
    public int number; //自身所在关卡
    public override void PutInPools()
    {
        op.pools[index].Push(gameObject); //将自己压进索引对应的栈中
    }
}
