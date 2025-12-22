using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Mover_inicial : MonoBehaviour
{   
    private PlayerData_SO player;
    private PlayerData_Json playerJson;

    public ButtonSoundController sound;
    public GameObject nivel;
    public GameObject atributos;
    public GameObject menu_1;
    public GameObject Player;
    public GameObject Armas;
    public GameObject Pontos;
    public GameObject Subclasse;
    public GameObject popup;
    private Vector3 posOriginalPlayer;
    private Vector3 escalaOriginalPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        popup.SetActive(false);
        atributos.SetActive(true);
        Armas.SetActive(false);   
        Subclasse.SetActive(false);  
        Pontos.SetActive(false);
        posOriginalPlayer = Player.transform.position;
        escalaOriginalPlayer = Player.transform.localScale;
        player = DadosJogador.Instance_jogador.playerData;
        playerJson = DadosJogador.Instance_jogador.jsonData;

    }
    public void Mover_1()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(false);   
        Subclasse.SetActive(true);
        Pontos.SetActive(false);
        StartCoroutine(MoverEScalear(Player, Player.transform.position + new Vector3(-1f, 0f, 0f), new Vector3(1.2f, 1.2f, Player.transform.localScale.z), 0.5f));    }
    public void Voltar_1()
    {
        sound.PlayClickSound();
        menu_1.SetActive(true);
        atributos.SetActive(true);
        Armas.SetActive(false);   
        Subclasse.SetActive(false);
        Pontos.SetActive(false);
        StartCoroutine(MoverEScalear(Player, posOriginalPlayer, escalaOriginalPlayer, 0.5f));
    }
    public void Mover_2()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(true);   
        Subclasse.SetActive(false);
        Pontos.SetActive(false);
    }
    public void Voltar_2()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(false);   
        Subclasse.SetActive(true);
        Pontos.SetActive(false);
    }
    public void Mover_3()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(false);   
        Subclasse.SetActive(false);
        Pontos.SetActive(true);
    }
    public void Voltar_3()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(true);   
        Subclasse.SetActive(false);
        Pontos.SetActive(false);
    }
    public void Mover_4()
    {
        sound.PlayClickSound();
        menu_1.SetActive(false);
        atributos.SetActive(false);
        Armas.SetActive(false);   
        Subclasse.SetActive(false);
        Pontos.SetActive(true);
        popup.SetActive(true);
    }
    public void Irparatutorial()
    {
        sound.PlayClickSound();
        playerJson.name = player.name;

        playerJson.characterClass = player.characterClass;
        playerJson.subclass = player.subclass;
        playerJson.subclass_traits = player.subclass_traits;
        playerJson.spells = player.spells;
        playerJson.is_summoner = player.is_summoner;

        playerJson.race = player.race;
        playerJson.gender = player.gender;
        playerJson.color = player.color;

        playerJson.talents = player.talents;
        playerJson.weapons = player.weapons;
        playerJson.attack_effect = player.attack_effect;

        playerJson.sabedoria = player.sabedoria;
        playerJson.inteligencia = player.inteligencia;
        playerJson.carisma = player.carisma;
        playerJson.forca = player.forca;
        playerJson.contituicao = player.contituicao;
        playerJson.destreza = player.destreza;


        string json = JsonUtility.ToJson(playerJson, true);
        string path = Path.Combine(Application.persistentDataPath, "Player.json");
        File.WriteAllText(path, json);
        Debug.Log(path);
        SceneManager.LoadScene("tutorial");
    }
    private IEnumerator MoverEScalear(GameObject alvo, Vector3 posFinal, Vector3 escalaFinal, float duracao)
    {
        Vector3 posInicial = alvo.transform.position;
        Vector3 escalaInicial = alvo.transform.localScale;

        float tempo = 0f;

        while (tempo < duracao)
        {
            float t = tempo / duracao;

            alvo.transform.position = Vector3.Lerp(posInicial, posFinal, t);
            alvo.transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, t);

            tempo += Time.deltaTime;
            yield return null;
        }

        // garante o valor final exato
        alvo.transform.position = posFinal;
        alvo.transform.localScale = escalaFinal;
    }


}
