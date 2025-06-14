using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using Newtonsoft.Json;
using TipagemClasses;
public class SelecionarRaca : MonoBehaviour
{
    public Personagens person;
    public ButtonSoundController sound;
    public TextMeshProUGUI uiText;   // Referência ao componente de texto da UI
    public string[] messages;
    public string[] raca;
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite[] sprites;           // Array de imagens (sprites) que serão trocadas
    private int currentIndex = 0;

    void Start()
    {
        raca = new string[] { "Humano", "Orc", "Elfo", "Demonio", "Anao" };
        person.Raca = raca[0];
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
        person.Raca = raca[currentIndex];
        person.Mudar();
        sound.PlayClickSound();
    }
    public void PreviousImage()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Raca = raca[currentIndex];
        person.Mudar();
        sound.PlayClickSound();
    }
}
