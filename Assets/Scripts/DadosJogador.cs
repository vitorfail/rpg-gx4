using UnityEngine;


public class DadosJogador  : MonoBehaviour
{
    public TextAsset player_json;
    public static DadosJogador Instance_jogador;
    public PlayerData_SO playerData;
    public event System.Action OnPlayerStatsChanged;
    void Awake()
    {   
        Instance_jogador = this;

        // Criar instância em runtime
        playerData = ScriptableObject.CreateInstance<PlayerData_SO>();

        // Deserializar JSON
        LoadPlayerData();

    }


    public void NotifyStatsChanged()
    {
        OnPlayerStatsChanged?.Invoke();
    }
    private void LoadPlayerData()
    {
        if (player_json == null)
        {
            Debug.LogError("Arquivo JSON do player não foi atribuído!");
            return;
        }

        // Deserializar o JSON diretamente para Character_Tipagem
        PlayerData_Json jsonData = JsonUtility.FromJson<PlayerData_Json>(player_json.text);
        // Copiar dados para o ScriptableObject
        playerData.name = jsonData.name;

        playerData.characterClass = jsonData.characterClass;
        playerData.subclass = jsonData.subclass;
        playerData.subclass_traits = jsonData.subclass_traits;
        playerData.spells = jsonData.spells;
        playerData.is_summoner = jsonData.is_summoner;

        playerData.race = jsonData.race;
        playerData.gender = jsonData.gender;
        playerData.color = jsonData.color;

        playerData.talents = jsonData.talents;
        playerData.weapons = jsonData.weapons;
        playerData.attack_effect = jsonData.attack_effect;

        playerData.sabedoria = jsonData.sabedoria;
        playerData.inteligencia = jsonData.inteligencia;
        playerData.carisma = jsonData.carisma;
        playerData.forca = jsonData.forca;
        playerData.contituicao = jsonData.contituicao;
        playerData.destreza = jsonData.destreza;
        NotifyStatsChanged();
    }
}
