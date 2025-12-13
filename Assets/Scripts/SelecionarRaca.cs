using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Newtonsoft.Json;
using TipagemClasses;
public class SelecionarRaca : MonoBehaviour
{
    public TextAsset racas;
    private RacaEfeitos efeitos;
    public Personagens person;
    public ButtonSoundController sound;
    public TextMeshProUGUI uiText;   // Referência ao componente de texto da UI
    public string[] messages;
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite[] sprites;           // Array de imagens (sprites) que serão trocadas
    public int currentIndex = 0;

    void Start()
    {
        efeitos = JsonUtility.FromJson<RacaEfeitos>(racas.text);
        person.Raca = efeitos.racas[0].titulo;
        uiImage.sprite = sprites[0];
        uiText.text = messages[0];
        person.Mudar();
    }
    public class Testando
    {
        public int t { get; set; }          // string
    }
    public void NextImage()
    {
        if (sprites.Length == 0) return;

        currentIndex = (currentIndex + 1) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Raca = efeitos.racas[currentIndex].titulo;
        person.Mudar();
        sound.PlayClickSound();
    }
    public void PreviousImage()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Raca = efeitos.racas[currentIndex].titulo;
        person.Mudar();
        sound.PlayClickSound();
    }
}
