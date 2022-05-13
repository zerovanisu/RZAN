using UnityEngine;

[CreateAssetMenu]
public class Character_Data : ScriptableObject
{
    [SerializeField]

    public string Name;

    public int Level,

        Bust, Waist, Hip,

        Height, Weight,

        HP_Max, HP, Atc, M_Atc, Defense, M_Defense, Speed;

    //public string Skill, Spell;

}
