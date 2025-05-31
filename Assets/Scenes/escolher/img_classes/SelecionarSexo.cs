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
    public Image uiImageMan;
    public Image uiImageWoman;
                  // Referência para o componente Image da UI
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
        uiImageWoman.sprite = mulher;
        uiImageMan.sprite = homem_on;
        person.Sexo = "Homem";
        person.Mudar();
        sound.PlayClickSound();
    }
    public void Mulher()
    {
        uiImageWoman.sprite = mulher_on;
        uiImageMan.sprite = homem;
        person.Sexo = "Mulher";
        person.Mudar();
        sound.PlayClickSound();
    }
}
