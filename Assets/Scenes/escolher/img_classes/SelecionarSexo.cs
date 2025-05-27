using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using Newtonsoft.Json;
using TipagemClasses;
public class SelecionarSexo : MonoBehaviour
{
    public Personagens person;
    public ButtonSoundController sound;
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite homem;
    public Sprite mulher;   
    public Sprite homem_on;
    public Sprite mulher_on;   
       // Array de imagens (sprites) que serão trocadas

    void Start()
    {
        
    }
    public void Homem()
    {
        uiImage.sprite = homem_on;
        person.Desaparecer();

        person.Sexo = "Homem";
        person.Mudar();
        sound.PlayClickSound();
    }
    public void Mulher()
    {
        uiImage.sprite = mulher;
        person.Desaparecer();
        person.Sexo = "Mulher";
        person.Mudar();
        sound.PlayClickSound();
    }
}
