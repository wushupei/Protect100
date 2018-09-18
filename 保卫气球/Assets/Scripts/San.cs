using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class San : MonoBehaviour
{
    public Transform qiQiu; //将气球拖进去
    void Update()
    {
        if (qiQiu != null)
        {
            Vector3 v = transform.position - qiQiu.position; //获取气球到自身的方向
            transform.rotation = Quaternion.FromToRotation(Vector3.up, v); //Y轴始终朝向该方向
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition)+Vector3.forward; //通过坐标系转换让雨伞跟随鼠标移动
        }
    }
}
