using System;

[Serializable]
public class Character_Tipagem
{
    public string name;

    public int characterClass;
    public int? subclass;
    public int[] subclass_traits;
    public int[] spells;
    public bool is_summoner;

    public int race;
    public int gender;
    public float[] color;     // RGB size 3

    public int[] talents;
    public int[] weapons;
    public int? attack_effect;
    public int sabedoria;
    public int inteligencia;
    public int carisma;
    public int forca;
    public int contituicao;
    public int destreza;

}
