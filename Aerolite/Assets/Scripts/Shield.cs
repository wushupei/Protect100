using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour //能量盾
{
    public Transform player; //将主舰拖进去
    public ScoreText scoreText; //将分数文本拖进去
    public AudioClip clip; //音效素材
    public GameObject spark; //粒子特效
    int scroe; //分数   
    void Update()
    {
        if (player != null)
        {
            Vector3 v = transform.position - player.position; //获取主角到自身的方向
            transform.rotation = Quaternion.FromToRotation(Vector3.up, v); //Y轴始终朝向该方向
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + Vector3.forward; //通过坐标系转换让能量盾跟随鼠标移动
        }
    }
    private void OnCollisionEnter2D(Collision2D c) //碰撞时调用一次
    {               
        AudioSource.PlayClipAtPoint(clip, player.position); //播放声音       
        foreach (var item in c.contacts) 
        {
            Vector2 hitPoint = item.point; //获取碰撞点位置
            Instantiate(spark, hitPoint, Quaternion.identity); //在该位置生成火花特效
        }
        scoreText.ShowScore(++scroe); //加一分并显示
    }
}
