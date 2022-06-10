using UnityEngine;

[System.Serializable]
public class CharaData_Entity : ScriptableObject
{
    public CharaData_Entity[] Datas;

    public string Name;

    public int Level,

        Bust, Waist, Hip,

        Height, Weight,

        HP_Max, HP, Atc, M_Atc, Defense, M_Defense, Speed;
}
