using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [Header("生成位置")]
    [SerializeField]
    GameObject[] Point;

    [Header("アイテム")]
    [SerializeField]
    GameObject Item;

    [Header("乱数")]
    [SerializeField]
    int Create_Number;

    [Header("生成時間")]
    [SerializeField]
    float Create_Time;

    [Header("生成時間のカウントダウン")]
    [SerializeField]
    float C_Time;

    [Header("生成数")]
    [SerializeField]
    int Quantity;

    [Header("ゲームディレクター")]
    [SerializeField]
    GameObject Director;

    [Header("ゴール")]
    [SerializeField]
    GameObject GOAL;

    [Header("ゴール生成フラグ")]
    [SerializeField]
    bool Goaled;

    void Start()
    {
        C_Time = Create_Time;
        Goaled = false;
    }

    void Update()
    {
        C_Time -= Time.deltaTime;

        if(C_Time <= 0)
        {
            if (Quantity > 0)
            {
                Create_Number = Random.Range(0, 2);
                Vector3 vec = Point[Create_Number].transform.position;
                Instantiate(Item, vec, Quaternion.identity);
                C_Time = Create_Time;

                Quantity -= 1;
            }
            else if (Quantity == 0 && Goaled == false)
            {
                Vector3 G_vec = Point[1].transform.position;
                Instantiate(GOAL, G_vec, Quaternion.identity);

                Goaled = true;
            }
        }
    }
}
