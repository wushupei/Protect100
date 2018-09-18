using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePoint : MonoBehaviour
{
    public GameObject LevelText; //将关卡Text拖进去
    int levelNumber; //关卡计数器
    public List<GameObject> weapons; //所有武器的集合
    float value_Y; //声明自身Y轴坐标

    ObjectPool op; //声明对象池
    void Start()
    {
        value_Y = transform.position.y; //获取自身Y轴坐标
        InvokeRepeating("Create", 1, 1);
        op = FindObjectOfType<ObjectPool>(); //找到对象池脚本
    }
    void Create()
    {
        //生成关卡字幕
        GameObject levelText;
        if (op.levelText.Count > 0) //如果对象池有货
        {
            levelText = op.levelText.Pop();
            levelText.SetActive(true);
        }
        else //没货重新创建
        {
            levelText = Instantiate(LevelText); 
        }
        //位置和显示
        levelText.transform.position = transform.position + Vector3.up * 2; 
        levelText.GetComponent<TextMesh>().text = "第 " + (++levelNumber).ToString() + " 刀";

        int index = Random.Range(0, weapons.Count); //随机获取一个武器
        for (int i = 0; i < transform.childCount; i++) //在每个子物体位置生成一个武器
        {
            GameObject weapon;
            if (op.pools[index].Count > 0) //如果该武器对象池里有存货
            {
                weapon = op.pools[index].Pop(); //直接调货
                weapon.SetActive(true);
                weapon.transform.rotation = weapons[index].transform.rotation; //初始化旋转
            }
            else //没有存货则重新生产
            {
                //生成的物体要添加2D刚体,添加2D多边形碰撞器,再添加上2D物理材质
                weapon = Instantiate(weapons[index]);
               
                weapon.AddComponent<Weapon>().index = index; //得到自己在数组的索引
                weapon.GetComponent<Weapon>().number = levelNumber; //得到自己所在的关卡
            }
            
            weapon.transform.position = transform.GetChild(i).position; //为得到的武器赋予位置
        }
    }
    void Update()
    {
        //随着时间升高位置,这样生成的武器落下时才有更高加速度
        transform.position = new Vector3(0, value_Y + Time.time, 0);
    }
}
