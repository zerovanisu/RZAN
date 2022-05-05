using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Chara_Preview : MonoBehaviour
{
    Character_Data Data;

    string FilePath = "Assets/Script/CharaData/Ayana_Data.asset";

    void Start()
    {
        Data = AssetDatabase.LoadAssetAtPath<Character_Data>(FilePath);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(Data);
        }
    }
}
