using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BJ : MonoBehaviour
{
    Renderer rend;
    float speed=1; //速度
    public TextMesh text;
    void Start()
    {
        rend = GetComponent<Renderer>(); //获取渲染组件
    }
    void Update()
    {
        speed += Time.deltaTime * 0.1f; //加速度
        rend.material.mainTextureOffset = new Vector2(speed * speed, 0); //纹理往上偏移
    }
}
