using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiQiu : MonoBehaviour
{
    Animator anima;
    int weaponNumber; //用于获取攻击自己的武器的编号
    public GameObject levelText;
    void Start()
    {
        anima = GetComponent<Animator>(); //获取动画管理组件 
    }
    void Update()
    {
        //动画播放完后执行
        AnimatorStateInfo stateinfo = anima.GetCurrentAnimatorStateInfo(0);
        //将当前动画时长归一化,如果正在播放该动画且超过1s,则判定为动画播放完了
        if (stateinfo.IsName("Base Layer.Boom") && stateinfo.normalizedTime > 1.0f)
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) //被碰撞播放动画
    {
        weaponNumber = other.gameObject.GetComponent<Weapon>().number;
        anima.SetBool("Boom", true);
    }
    void Death() //死亡方法
    {
        //祭出死亡字幕
        TextMesh deathText = Instantiate(levelText, transform.position + Vector3.back, Quaternion.identity).GetComponent<TextMesh>(); ;
        deathText.text = "死于第 " + weaponNumber.ToString() + " 刀";
        deathText.color = Color.red;

        Destroy(gameObject); //销毁自身
        Time.timeScale = 0; //时间暂停
    }
}
