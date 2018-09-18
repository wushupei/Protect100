using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    SpriteRenderer[] son; //保存所有子物体
    Sprite[] numbers; //储存所有的数字图片 

    void Start()
    {
        son = GetComponentsInChildren<SpriteRenderer>();
        numbers = Resources.LoadAll<Sprite>("素材/图片/Number");
    }

    public void ShowScore(int score) //根据分数更换精灵图片
    {
        switch (score.ToString().Length) //判断分数的位数
        {
            case 1:
                son[0].sprite = numbers[score]; //取个位
                break;
            case 2:
                son[0].sprite = numbers[score % 10];
                son[1].sprite = numbers[score / 10]; //取十位
                break;
            case 3:
                son[0].sprite = numbers[score % 100];
                son[1].sprite = numbers[score / 10 % 10];
                son[2].sprite = numbers[score / 100]; //取百位
                break;
        }
    }
}
