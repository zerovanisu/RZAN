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
        Spinel = 0, Sapphire = 1, Peridot = 2
    }

    [SerializeField]
    GameObject Detail_Canvas, List_Canvas;

    [SerializeField]
    Image Tachie;
    Character_Data Data;
    
    [SerializeField]
    int Chara_ID;
    [SerializeField]
    Text[] Status_Text;
    [SerializeField]
    string[] Status_Name;

    //Dictionary<int, string> S_Name = new Dictionary<int, string>();

    string filePath = "Assets/Script/CharaData/";
    string imagePath = "";
    //string[] fileName = new string[3]{"Spinel_Data", "Peridot_Data", "Sapphire_Data" };


     public Character_Data LoadCharacterData(CHARATYPE type)
    {
        //var path = $"{filePath}{fileName[(int)type]}.asset";
        var path = $"{filePath}{(CHARATYPE)Enum.ToObject(typeof(CHARATYPE),Chara_ID)}_Data.asset";
        return AssetDatabase.LoadAssetAtPath<Character_Data>(path);
        //
    }

    public void Detail_Update(int id)
    {
        Chara_ID = id;
        Data = LoadCharacterData((CHARATYPE)Enum.ToObject(typeof(CHARATYPE), Chara_ID));
        Tachie.sprite = Data.Icon;
        Text_Update();

        //Canvasの切り替え
        Detail_Canvas.SetActive(true);
        List_Canvas.SetActive(false);
    }

    //詳細のテキスト表示処理
    void Text_Update()
    {
        Status_Text[0].text = Data.Name.ToString();
        Status_Text[1].text = Data.Level.ToString();
        Status_Text[2].text = Data.Bust.ToString();
        Status_Text[3].text = Data.Waist.ToString();
        Status_Text[4].text = Data.Hip.ToString();
        Status_Text[5].text = Data.Height.ToString();
        Status_Text[6].text = Data.Weight.ToString();
        Status_Text[7].text = Data.HP_Max.ToString();
        Status_Text[8].text = Data.Atc.ToString();
        Status_Text[9].text = Data.M_Atc.ToString();
        Status_Text[10].text = Data.Defense.ToString();
        Status_Text[11].text = Data.M_Defense.ToString();
        Status_Text[12].text = Data.Speed.ToString();
    }

    //Canvasを元に戻す
    public void CanvasChange()
    {
        Detail_Canvas.SetActive(false);
        List_Canvas.SetActive(true);
    }

    /*void Test()
    {
        for (int i = 0; i < Status_Name.Length; i++)
        {
            S_Name.Add(i, Status_Name[i]);
        }

        for (int i = 0; i < Status_Name.Length; i++)
        {
            Status_Text[i].text = Data.S_Name[i].ToString();
        }

    }*/
}
