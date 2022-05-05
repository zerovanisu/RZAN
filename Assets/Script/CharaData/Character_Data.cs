using UnityEngine;

[CreateAssetMenu]
public class Character_Data : ScriptableObject
{
    [SerializeField]

    public string Name, Full_Name;

    public string Weapon;

    public int Level,
        
        HP_Max,
        
        HP,
        
        Atc,

        M_Atc,
        
        Defense,
        
        M_Defense,
        
        Speed;

    public string Skill, Spell;

}
