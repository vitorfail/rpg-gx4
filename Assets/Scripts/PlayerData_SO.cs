using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "RPG/Player Data")]
public class PlayerData_SO : ScriptableObject
{
    [Header("Identidade")]
    public string name;

    [Header("Classe")]
    public int characterClass;
    public int? subclass;
    public int[] subclass_traits;

    [Header("Magias")]
    public int[] spells;
    public bool is_summoner;

    [Header("Aparência")]
    public int race;
    public int gender;
    public float[] color; // RGB

    [Header("Talentos e Armas")]
    public int[] talents;
    public string[] weapons;

    [Header("Combate")]
    public int? attack_effect;

    [Header("Atributos")]
    public int sabedoria;
    public int inteligencia;
    public int carisma;
    public int ca;
    public int forca;
    public int contituicao;
    public int destreza;

    // Método auxiliar opcional
}
