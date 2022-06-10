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
            //　IndexOfの引数は"/(読み込ませたいファイル名)"とする。
            if (str.IndexOf("/CharaDataCSV.csv") != -1)
            {
                TextAsset textasset = Resources.Load<TextAsset>(str);
                //　同名のScriptableObjectファイルを読み込む。ない場合は新たに作る。
                string assetfile = str.Replace(".csv", ".asset");
                //　※"MonsterDataBase"はScriptableObjectのクラス名に合わせて変更する。
                CharaData_Entity md = Resources.Load<CharaData_Entity>(assetfile);
                if (md == null)
                {
                    md = new CharaData_Entity();
                    AssetDatabase.CreateAsset(md, assetfile);
                }
                //　※"ChararData_Entity"はScriptableObjectに入れるデータのクラス名に合わせて変更。
                //　※"Datas"もScriptableObjectが保有する配列名に合わせる。
                md.Datas = CSVSerializer.Deserialize<CharaData_Entity>(textasset.text);
                EditorUtility.SetDirty(md);
                AssetDatabase.SaveAssets();
            }
        }
    }
}
#endif
