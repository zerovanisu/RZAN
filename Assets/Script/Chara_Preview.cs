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
    ExcelData Data;
    
    [SerializeField]
    int Chara_ID;
    [SerializeField]
    Text[] Status_Text;

    //Dictionary<int, string> S_Name = new Dictionary<int, string>();

    string DataPath = "Assets/Excel/ExcelData.asset";
    string ImagePath = "Assets/Image/";//スピネル/Spinel_1.png

    public Image LoadImageData(CHARATYPE type)
    {
        var path = $"{ImagePath}{(CHARATYPE)Enum.ToObject(typeof(CHARATYPE), Chara_ID)}/";
        return AssetDatabase.LoadAssetAtPath<Image>(path);
    }

    public void Detail_Update(int id)
    {
        Chara_ID = id;
        Data = AssetDatabase.LoadAssetAtPath<ExcelData>(DataPath);
        //Tachie = LoadImageData((CHARATYPE)Enum.ToObject(typeof(CHARATYPE), Chara_ID));
        Text_Update();

        //Canvasの切り替え
        Detail_Canvas.SetActive(true);
        List_Canvas.SetActive(false);
    }

    //詳細のテキスト表示処理
    void Text_Update()
    {

        Status_Text[0].text = Data.CharaData[Chara_ID].Name.ToString();
        Status_Text[1].text = Data.CharaData[Chara_ID].Level.ToString();
        Status_Text[2].text = Data.CharaData[Chara_ID].Bust.ToString();
        Status_Text[3].text = Data.CharaData[Chara_ID].Waist.ToString();
        Status_Text[4].text = Data.CharaData[Chara_ID].Hip.ToString();
        Status_Text[5].text = Data.CharaData[Chara_ID].Height.ToString();
        Status_Text[6].text = Data.CharaData[Chara_ID].Weight.ToString();
        Status_Text[7].text = Data.CharaData[Chara_ID].HP_Max.ToString();
        Status_Text[8].text = Data.CharaData[Chara_ID].Atc.ToString();
        Status_Text[9].text = Data.CharaData[Chara_ID].M_Atc.ToString();
        Status_Text[10].text = Data.CharaData[Chara_ID].Defense.ToString();
        Status_Text[11].text = Data.CharaData[Chara_ID].M_Defense.ToString();
        Status_Text[12].text = Data.CharaData[Chara_ID].Speed.ToString();
    }

    //Canvasを元に戻す
    public void CanvasChange()
    {
        Detail_Canvas.SetActive(false);
        List_Canvas.SetActive(true);
    }
}
