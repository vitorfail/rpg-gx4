using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SelecionarClasses : MonoBehaviour
{
    public Personagens person;
    public ButtonSoundController sound;
    public TextMeshProUGUI uiText;   // Referência ao componente de texto da UI
    public string[] messages;  
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite[] sprites;           // Array de imagens (sprites) que serão trocadas
    private int currentIndex = 0;
    public void NextImage()
    {
        if (sprites.Length == 0) return;

        currentIndex = (currentIndex + 1) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Classes = messages[currentIndex];
        sound.PlayClickSound();
    }
    public void PreviousImage()
    {
        if (sprites.Length == 0) return;
        currentIndex = (currentIndex - 1 + sprites.Length) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Classes = messages[currentIndex];
        sound.PlayClickSound();
    }
}
