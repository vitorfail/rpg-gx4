using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ArmaChange : MonoBehaviour
{   
    [System.Serializable]
    public class ArmaData
    {
        public string nome;
        public string titulo;
        public GameObject handler;
        public List<JsonArmas> listaArmas;
        public int index;
    }

    [System.Serializable]
    public class JsonArmas
    {
        public string nome;
        public string titulo;
    }

    public Personagens Render_Arma;
    
    // Handlers no inspector
    public GameObject EspadasHandler;
    public GameObject BanjoHandler;
    public GameObject CajadosHandler;
    public GameObject MachadosHandler;
    public GameObject MartelosHandler;
    public GameObject ArcosHandler;

    private Dictionary<string, ArmaData> armasData;
    private ArmaData armaAtual;
    private TextMeshProUGUI textoAtual;

    // Listas de armas
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

    private List<JsonArmas> listaMachado = new List<JsonArmas>()
    {
        new JsonArmas() { nome = "Machado-1", titulo = "Machado de Antares" },
        new JsonArmas() { nome = "Machado-2", titulo = "Machado do Abismo" },
        new JsonArmas() { nome = "Machado-3", titulo = "Machado de Asis" },
        new JsonArmas() { nome = "Machado-4", titulo = "Machado Da Perdição" }
    };

    private List<JsonArmas> listaMartelos = new List<JsonArmas>()
    {
        new JsonArmas() { nome = "Martelo-1", titulo = "Martelo do Purgatório" },
        new JsonArmas() { nome = "Martelo-2", titulo = "Destino dos Justos" },
        new JsonArmas() { nome = "Martelo-3", titulo = "Fim do Túnel" },
        new JsonArmas() { nome = "Martelo-4", titulo = "Martelo Celestial" },
        new JsonArmas() { nome = "Martelo-5", titulo = "Esmaga Demônios" }
    };

    private List<JsonArmas> listaArco = new List<JsonArmas>()
    {
        new JsonArmas() { nome = "Arco-1", titulo = "Arco da Matriz" },
        new JsonArmas() { nome = "Arco-2", titulo = "Arco Zoonder" },
        new JsonArmas() { nome = "Arco-3", titulo = "Arco Mastral" },
        new JsonArmas() { nome = "Arco-4", titulo = "Arco de Luz" }
    };

    void Start()
    {   
        InicializarArmasData();
        DesativarTodosHandlers();
        
        // Configurar arma inicial baseada na classe
        if (Render_Arma.Classes == "Barbaro" || Render_Arma.Classes == "Guerreiro" || 
            Render_Arma.Classes == "Paladino")
        {
            AtivarArma("espada");
        }
        else if (Render_Arma.Classes == "Mago" || Render_Arma.Classes == "Druida" || 
                 Render_Arma.Classes == "Bruxo" || Render_Arma.Classes == "Feiticeiro" || 
                 Render_Arma.Classes == "Clerigo")
        {
            AtivarArma("cajado");
        }
    }

    private void InicializarArmasData()
    {
        armasData = new Dictionary<string, ArmaData>()
        {
            { "espada", new ArmaData { 
                handler = EspadasHandler, 
                listaArmas = listaEspadas, 
                index = 0 
            }},
            { "banjo", new ArmaData { 
                handler = BanjoHandler, 
                listaArmas = new List<JsonArmas>(), // Adicione os dados do banjo se necessário
                index = 0 
            }},
            { "cajado", new ArmaData { 
                handler = CajadosHandler, 
                listaArmas = listaCajados, 
                index = 0 
            }},
            { "machado", new ArmaData { 
                handler = MachadosHandler, 
                listaArmas = listaMachado, 
                index = 0 
            }},
            { "martelo", new ArmaData { 
                handler = MartelosHandler, 
                listaArmas = listaMartelos, 
                index = 0 
            }},
            { "arco", new ArmaData { 
                handler = ArcosHandler, 
                listaArmas = listaArco, 
                index = 0 
            }}
        };
    }

    private void DesativarTodosHandlers()
    {
        foreach (var arma in armasData.Values)
        {
            if (arma.handler != null)
                arma.handler.SetActive(false);
        }
    }

    public void NextArma()
    {
        if (armaAtual == null || armaAtual.listaArmas.Count == 0) return;

        armaAtual.index = (armaAtual.index + 1) % armaAtual.listaArmas.Count;
        AtualizarArmaVisual();
    }

    public void PrevArma()
    {
        if (armaAtual == null || armaAtual.listaArmas.Count == 0) return;

        armaAtual.index = (armaAtual.index - 1 + armaAtual.listaArmas.Count) % armaAtual.listaArmas.Count;
        AtualizarArmaVisual();
    }

    private void AtualizarArmaVisual()
    {
        var armaSelecionada = armaAtual.listaArmas[armaAtual.index];
        
        // Atualizar texto
        if (textoAtual != null)
            textoAtual.text = armaSelecionada.titulo;
        
        // Atualizar renderização
        string comando = $"Items/Armas/{GetTipoArmaPasta(armaAtual)}/{armaSelecionada.nome}/{armaSelecionada.nome}";
        Render_Arma.Render_Arma(comando);
    }

    private string GetTipoArmaPasta(ArmaData armaData)
    {
        // Mapeia a chave do dicionário para o nome da pasta
        foreach (var pair in armasData)
        {
            if (pair.Value == armaData)
                return pair.Key switch
                {
                    "espada" => "Espadas",
                    "cajado" => "Cajados",
                    "machado" => "Machados",
                    "martelo" => "Martelos",
                    "arco" => "Arcos",
                    "banjo" => "Banjos", // Ajuste conforme necessário
                    _ => "Espadas"
                };
        }
        return "Espadas";
    }

    public void AtivarArma(string tipoArma)
    {
        if (armasData.ContainsKey(tipoArma))
        {
            DesativarTodosHandlers();
            
            armaAtual = armasData[tipoArma];
            armaAtual.handler.SetActive(true);
            
            // Configurar texto atual
            textoAtual = armaAtual.handler.transform.Find("TextoHandler")?.GetComponent<TextMeshProUGUI>();
            
            if (armaAtual.listaArmas.Count > 0)
            {
                AtualizarArmaVisual();
            }
        }
    }

    // Métodos públicos para os botões (mantendo compatibilidade)
    public void Botao_espada() => AtivarArma("espada");
    public void Botao_banjo() => AtivarArma("banjo");
    public void Botao_cajado() => AtivarArma("cajado");
    public void Botao_machado() => AtivarArma("machado");
    public void Botao_martelo() => AtivarArma("martelo");
    public void Botao_arco() => AtivarArma("arco");
}