using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail_Open : MonoBehaviour
{
    [SerializeField]
    public int ID;
    public GameObject P_Manager;

    public void Open()
    {
        P_Manager = GameObject.Find("Preview_Manager");
        P_Manager.GetComponent<Chara_Preview>().Detail_Update(ID);
    }
}
