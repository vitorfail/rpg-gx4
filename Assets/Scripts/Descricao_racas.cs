using System.Collections;
using TMPro;
using UnityEngine;


public class Descricao_racas : MonoBehaviour
{
    public TextAsset jsonracas;
    public GameObject popup_;
    private RacaEfeitos efeitos;
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI valor;
    public SelecionarRaca selecionarRaca;
    public ButtonSoundController sound;

    void Start()
    {
        efeitos = JsonUtility.FromJson<RacaEfeitos>(jsonracas.text);
    }
    public void Popup_Raca()
    {
        titulo.text = efeitos.racas[selecionarRaca.currentIndex].titulo;
        valor.text = efeitos.racas[selecionarRaca.currentIndex].descri;
        Popup.Instancia.AtivarComFade(popup_, 0.2f, 0.1f);
        sound.PlayClickSound();
    }
    public void Fechar()
    {
        popup_.SetActive(false);
        sound.PlayClickSound();
    }

}