using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJ : MonoBehaviour
{
    Renderer rend; 
    void Start()
    {
        rend = GetComponent<Renderer>(); //获取渲染组件
    }
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(0, Time.time*Time.time*0.02f); //纹理往上偏移
    }
}
