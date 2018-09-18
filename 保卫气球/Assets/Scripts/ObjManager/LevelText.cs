using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : ObjManager
{
    public override void PutInPools()
    {
        op.levelText.Push(gameObject); //将自己压进对应的栈中
    }
}
