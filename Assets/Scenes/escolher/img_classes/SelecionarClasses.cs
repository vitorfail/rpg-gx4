using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class SelecionarClasses : MonoBehaviour
{
    public Personagens person;
    public ButtonSoundController sound;
    public TextMeshProUGUI uiText;   // Referência ao componente de texto da UI
    public string[] messages;
    public string[] clas;
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite[] sprites;           // Array de imagens (sprites) que serão trocadas
    private int currentIndex = 0;
    public void NextImage()
    {
        clas = new string[] { "Barbaro","Bardo","Bruxo","Clerigo","Druida","Feiticeiro","Guerreiro","Ladino","Monge","Paladino","Mago","Ranger",};
        if (sprites.Length == 0) return;

        currentIndex = (currentIndex + 1) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Desaparecer();
        person.Classes = clas[currentIndex];
        person.Mudar();
        sound.PlayClickSound();
    }
    public void PreviousImage()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Desaparecer();
        person.Classes = clas[currentIndex];
        person.Mudar();
        sound.PlayClickSound();
    }
}
