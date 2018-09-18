using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anima; //动画
    public AudioClip boom; //声音
    public GameObject button; //重启按钮
    void Start()
    {
        button.SetActive(false); //隐藏按钮
        anima = GetComponent<Animator>(); //获取动画管理组件 
        Time.timeScale = 1;
    }
    void Update()
    {
        //动画播放完后执行
        AnimatorStateInfo stateinfo = anima.GetCurrentAnimatorStateInfo(0);
        //将当前动画时长归一化,如果正在播放该动画且超过1s,则判定为动画播放完了
        if (stateinfo.IsName("Base Layer.Boom") && stateinfo.normalizedTime > 1.0f)
        {
            Destroy(gameObject); //销毁自身
            Time.timeScale = 0; //时间暂停
            button.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //被碰撞播放动画
    {
        anima.SetBool("B", true); //播放动画
        transform.localScale *= 5; //变大
        AudioSource.PlayClipAtPoint(boom, transform.position); //播放声音
        Destroy(GetComponent<PolygonCollider2D>()); //移除碰撞器
    }
}
