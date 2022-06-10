using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

public class Csv_Importer : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAssets)
        {
            //�@IndexOf�̈�����"/(�ǂݍ��܂������t�@�C����)"�Ƃ���B
            if (str.IndexOf("/CharaDataCSV.csv") != -1)
            {
                TextAsset textasset = Resources.Load<TextAsset>(str);
                //�@������ScriptableObject�t�@�C����ǂݍ��ށB�Ȃ��ꍇ�͐V���ɍ��B
                string assetfile = str.Replace(".csv", ".asset");
                //�@��"MonsterDataBase"��ScriptableObject�̃N���X���ɍ��킹�ĕύX����B
                CharaData_Entity md = Resources.Load<CharaData_Entity>(assetfile);
                if (md == null)
                {
                    md = new CharaData_Entity();
                    AssetDatabase.CreateAsset(md, assetfile);
                }
                //�@��"ChararData_Entity"��ScriptableObject�ɓ����f�[�^�̃N���X���ɍ��킹�ĕύX�B
                //�@��"Datas"��ScriptableObject���ۗL����z�񖼂ɍ��킹��B
                md.Datas = CSVSerializer.Deserialize<CharaData_Entity>(textasset.text);
                EditorUtility.SetDirty(md);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
#endif
