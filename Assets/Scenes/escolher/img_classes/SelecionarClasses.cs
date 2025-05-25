using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;
using Newtonsoft.Json;
using TipagemClasses;
public class SelecionarClasses : MonoBehaviour
{
    public TextMeshProUGUI text_hp;
    public TextAsset json_class;
    public Atributos forca;
    public Atributos destreza;
    public Atributos cosntittuicao;
    public Atributos inteligencia;
    public Atributos sabedoria;
    public Atributos carisma;
    public Personagens person;
    public ButtonSoundController sound;
    public TextMeshProUGUI uiText;   // Referência ao componente de texto da UI
    public string[] messages;
    public string[] clas;
    public Image uiImage;              // Referência para o componente Image da UI
    public Sprite[] sprites;           // Array de imagens (sprites) que serão trocadas
    private int currentIndex = 0;
    public DndClassesData clastipagem;
    void Start()
    {
        clastipagem = JsonConvert.DeserializeObject<DndClassesData>(json_class.text);
        Debug.Log(clastipagem.Classes["barbaro"].Foco);

    }
    public void NextImage()
    {
        clas = new string[] { "Barbaro", "Bardo", "Bruxo", "Clerigo", "Druida", "Feiticeiro", "Guerreiro", "Ladino", "Monge", "Paladino", "Mago", "Ranger", };
        if (sprites.Length == 0) return;

        currentIndex = (currentIndex + 1) % sprites.Length;
        uiImage.sprite = sprites[currentIndex];
        uiText.text = messages[currentIndex];
        person.Desaparecer();
        if (clas[currentIndex] == "Barbaro")
        {
            forca.Attr(350.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(200.00f);
            inteligencia.Attr(30.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Bardo")
        {
            forca.Attr(100.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(60.00f);
            inteligencia.Attr(60.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Bruxo")
        {
            forca.Attr(20.00f);
            destreza.Attr(60.00f);
            cosntittuicao.Attr(60.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Clerigo")
        {
            forca.Attr(60.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(350.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Druida")
        {
            forca.Attr(80.00f);
            destreza.Attr(70.00f);
            cosntittuicao.Attr(70.00f);
            inteligencia.Attr(350.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(80.00f);
        }
        if (clas[currentIndex] == "Feiticeiro")
        {
            forca.Attr(60.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Guerreiro")
        {
            forca.Attr(350.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Ladino")
        {
            forca.Attr(100.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(70.00f);
        }
        if (clas[currentIndex] == "Monge")
        {
            forca.Attr(100.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(150.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(70.00f);
        }
        if (clas[currentIndex] == "Paladino")
        {
            forca.Attr(150.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(200.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Mago")
        {
            forca.Attr(20.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(350.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Ranger")
        {
            forca.Attr(20.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(20.00f);
            carisma.Attr(80.00f);
        }
        Debug.Log(clastipagem.Classes["barbaro"].Descri);
        int hp = clastipagem.Classes[clas[currentIndex].ToLower()].Level[0].Hp;
        text_hp.text = "HP: " + hp;
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
        if (clas[currentIndex] == "Barbaro")
        {
            forca.Attr(350.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(200.00f);
            inteligencia.Attr(30.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Bardo")
        {
            forca.Attr(100.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(60.00f);
            inteligencia.Attr(60.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Bruxo")
        {
            forca.Attr(20.00f);
            destreza.Attr(60.00f);
            cosntittuicao.Attr(60.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Clerigo")
        {
            forca.Attr(60.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(350.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Druida")
        {
            forca.Attr(80.00f);
            destreza.Attr(70.00f);
            cosntittuicao.Attr(70.00f);
            inteligencia.Attr(350.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(80.00f);
        }
        if (clas[currentIndex] == "Feiticeiro")
        {
            forca.Attr(60.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Guerreiro")
        {
            forca.Attr(350.00f);
            destreza.Attr(100.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Ladino")
        {
            forca.Attr(100.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(80.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(70.00f);
        }
        if (clas[currentIndex] == "Monge")
        {
            forca.Attr(100.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(150.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(70.00f);
        }
        if (clas[currentIndex] == "Paladino")
        {
            forca.Attr(150.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(200.00f);
            inteligencia.Attr(80.00f);
            sabedoria.Attr(70.00f);
            carisma.Attr(350.00f);
        }
        if (clas[currentIndex] == "Mago")
        {
            forca.Attr(20.00f);
            destreza.Attr(30.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(350.00f);
            sabedoria.Attr(100.00f);
            carisma.Attr(100.00f);
        }
        if (clas[currentIndex] == "Ranger")
        {
            forca.Attr(20.00f);
            destreza.Attr(350.00f);
            cosntittuicao.Attr(100.00f);
            inteligencia.Attr(100.00f);
            sabedoria.Attr(20.00f);
            carisma.Attr(80.00f);
        }
        DndClassesData clastipagem = JsonUtility.FromJson<DndClassesData>(json_class.text);
        int hp = clastipagem.Classes[clas[currentIndex].ToLower()].Level[0].Hp;
        text_hp.text = "HP: "+hp;
        person.Classes = clas[currentIndex];
        person.Mudar();
        sound.PlayClickSound();
    }
}
