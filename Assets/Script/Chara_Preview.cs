using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Chara_Preview : MonoBehaviour
{
    public enum CHARATYPE
    {
        Spinel = 0, Peridot = 1, Sapphire = 2
    }

    [SerializeField]
    Image Tachie;
    Character_Data Data;
    
    [SerializeField]
    int Chara_ID;
    [SerializeField]
    Text[] Status_Name;
    string[] Chara_Status;

    string filePath = "Assets/Script/CharaData/";
    string imagePath = "";
    //string[] fileName = new string[3]{"Spinel_Data", "Peridot_Data", "Sapphire_Data" };


    void Start()
    {

    }

     public Character_Data LoadCharacterData(CHARATYPE type)
    {
        //var path = $"{filePath}{fileName[(int)type]}.asset";
        var path = $"{filePath}{(CHARATYPE)Enum.ToObject(typeof(CHARATYPE),Chara_ID)}_Data.asset";
        return AssetDatabase.LoadAssetAtPath<Character_Data>(path);
        //
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Data = LoadCharacterData((CHARATYPE)Enum.ToObject(typeof(CHARATYPE),Chara_ID));
            /*for(int i = Status_Name.Length; 0 < i; i--)
            {
                Status_Name[i].text = Chara_Status[i];
            }*/
            Status_Name[0].text = Data.Name;
        }
    }
}
