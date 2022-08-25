using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour
{
    [Header("�����ʒu")]
    [SerializeField]
    GameObject[] Point;

    [Header("�A�C�e��")]
    [SerializeField]
    GameObject Item;

    [Header("����")]
    [SerializeField]
    int Create_Number;

    [Header("��������")]
    [SerializeField]
    float Create_Time;

    [Header("�������Ԃ̃J�E���g�_�E��")]
    [SerializeField]
    float C_Time;

    [Header("������")]
    [SerializeField]
    int Quantity;

    [Header("�Q�[���f�B���N�^�[")]
    [SerializeField]
    GameObject Director;

    [Header("�S�[��")]
    [SerializeField]
    GameObject GOAL;

    [Header("�S�[�������t���O")]
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
