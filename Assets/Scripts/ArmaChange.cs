using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ArmaChange : MonoBehaviour
{   
    public GameObject EspadasHandler;
    public GameObject BanjoHandler;
    public GameObject CajadosHandler;
    public GameObject MachadosHandler;
    public GameObject Martelosandler;
    public GameObject ArcosHandler;
    private int index_espada;
    private int index_banjo;
    private int index_cajado;
    private int index_machado;
    private int index_martelo;
    private int index_arco;
    public Personagens Render_Arma;
    private TextMeshProUGUI temp;
    JsonArmas espada;
    [System.Serializable]
    private class JsonArmas
    {
        public string nome;
        public string titulo;
    }
    private List<JsonArmas> listaEspadas = new List<JsonArmas>()
    {
        new JsonArmas() { nome = "Espada-1", titulo = "Espada de Sangue" },
        new JsonArmas() { nome = "Espada-2", titulo = "Espada Negra" },
        new JsonArmas() { nome = "Espada-3", titulo = "Espada Celestial" }
    };
    private List<JsonArmas> listaCajados = new List<JsonArmas>()
    {
        new JsonArmas() { nome = "Cajado-1", titulo = "Cajado do Poder" },
        new JsonArmas() { nome = "Cajado-2", titulo = "Cajado do Destino" },
        new JsonArmas() { nome = "Cajado-3", titulo = "Cajado Diabólico" },
        new JsonArmas() { nome = "Cajado-4", titulo = "Cajado Da Floresta" }
    };
    void Start()
    {   
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(false);
        //text.text =espada.titulo;
        if (Render_Arma.Classes == "Barbaro" ||
         Render_Arma.Classes == "Guerreiro" || 
         Render_Arma.Classes == "Paladino" || 
         Render_Arma.Classes == "Barbaro")
        {
            EspadasHandler.SetActive(true);
            index_espada = 0;
            espada = listaEspadas[0]; 
            temp= EspadasHandler.transform.Find("TextoHandler").GetComponent<TextMeshProUGUI>();
            temp.text = espada.titulo;
        }
        if (Render_Arma.Classes=="Mago"|| 
        Render_Arma.Classes=="Druida" || 
        Render_Arma.Classes=="Bruxo"|| 
        Render_Arma.Classes=="Feiticeiro"||
         Render_Arma.Classes=="Clerigo")
        {
            CajadosHandler.SetActive(true);
            index_cajado = 0;
            espada = listaCajados[0]; 
            temp= CajadosHandler.transform.Find("TextoHandler").GetComponent<TextMeshProUGUI>();
            temp.text = espada.titulo;
        }

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Next_Espadas()
    {
        if(index_espada+1 == listaEspadas.Count)
        {
            index_espada = 0;
            espada = listaEspadas[0];
            temp.text = espada.titulo;
            string comand = "Items/Armas/Espadas/"+espada.nome+"/"+espada.nome;
            Render_Arma.Render_Arma(comand);
        }
        else
        {
            index_espada = index_espada+1;
            espada = listaEspadas[index_espada];
            temp.text = espada.titulo;
            string comand = "Items/Armas/Espadas/"+espada.nome+"/"+espada.nome;
            Render_Arma.Render_Arma(comand);
        }
    }
    public void Prev_Espadas()
    {
        if(index_espada <= 0)
        {
            index_espada = listaEspadas.Count-1;
            espada = listaEspadas[index_espada];
            temp.text = espada.titulo;
            string comand = "Items/Armas/Espadas/"+espada.nome+"/"+espada.nome;
            Render_Arma.Render_Arma(comand);

        }
        else
        {
            index_espada = index_espada-1;
            espada = listaEspadas[index_espada];
            temp.text = espada.titulo;
            string comand = "Items/Armas/Espadas/"+espada.nome+"/"+espada.nome;
            Render_Arma.Render_Arma(comand);
        }
    }
    public void Botao_espada()
    {
        Debug.Log("Passou1");
        EspadasHandler.SetActive(true);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(false);
    }
    public void Botao_banjo()
    {   
        Debug.Log("Passou2");
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(true);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(false);
    }
    public void Botao_cajado()
    {
        Debug.Log("Passou3");
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(true);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(false);
    }
    public void Botao_machado()
    {
        Debug.Log("Passou4");
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(true);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(false);
    }
    public void Botao_martelo()
    {
        Debug.Log("Passou5");
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(true);
        ArcosHandler.SetActive(false);
    }
    public void Botao_arco()
    {
        Debug.Log("Passou6");
        EspadasHandler.SetActive(false);
        BanjoHandler.SetActive(false);
        CajadosHandler.SetActive(false);
        MachadosHandler.SetActive(false);
        Martelosandler.SetActive(false);
        ArcosHandler.SetActive(true);
    }
}
