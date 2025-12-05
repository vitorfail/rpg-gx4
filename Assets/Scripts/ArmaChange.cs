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
        public GameObject Clicks;
        public List<JsonArmas> listaArmas;
        public int index;
        public List<string> classesPermitidas; // Classes que podem usar esta arma
    }


    public Personagens Render_Arma;
    
    // Handlers no inspector
    public GameObject EspadasHandler;
    public GameObject BanjoHandler;
    public GameObject CajadosHandler;
    public GameObject MachadosHandler;
    public GameObject MartelosHandler;
    public GameObject ArcosHandler;

    public GameObject Espadas_Click;
    public GameObject Banjo_Click;
    public GameObject Cajados_Click;
    public GameObject Machados_Click;
    public GameObject Martelos_Click;
    public GameObject Arcos_Click;
    private PlayerData_SO player;

    private Dictionary<string, ArmaData> armasData;
     public ArmasJson armas;
    private ArmaData armaAtual;
    private TextMeshProUGUI textoAtual;

    // Listas de armas
    private List<JsonArmas> listaEspadas = new List<JsonArmas>();
    private List<JsonArmas> listaCajados = new List<JsonArmas>();
    private List<JsonArmas> listaMachado = new List<JsonArmas>();
    private List<JsonArmas> listaMartelos = new List<JsonArmas>();
    private List<JsonArmas> listaArco = new List<JsonArmas>();
    private List<JsonArmas> listaBanjo = new List<JsonArmas>();

    void OnEnable()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Jsons/Armas");
        armas = JsonUtility.FromJson<ArmasJson>(jsonFile.text);
        listaEspadas = armas.listaEspadas;
        listaCajados = armas.listaCajados;
        listaMachado = armas.listaMachado;
        listaMartelos = armas.listaMartelos;
        listaArco = armas.listaArco;
        listaBanjo = armas.listaBanjo;
        InicializarArmasData();
        DesativarTodosHandlers();
        AtualizarRestricoesClasses();

        
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
        else if (Render_Arma.Classes == "Bardo")
        {
            AtivarArma("banjo");
        }
    }

    private void InicializarArmasData()
    {
        armasData = new Dictionary<string, ArmaData>()
        {
            { "espada", new ArmaData { 
                handler = EspadasHandler, 
                listaArmas = listaEspadas, 
                index = 0,
                classesPermitidas = new List<string> { "Guerreiro", "Paladino", "Ladino", "Ranger", "Barbaro" },
                Clicks = Espadas_Click
            }},
            { "banjo", new ArmaData { 
                handler = BanjoHandler, 
                listaArmas = listaBanjo, 
                index = 0,
                classesPermitidas = new List<string> { "Bardo" },
                Clicks = Banjo_Click
            }},
            { "cajado", new ArmaData { 
                handler = CajadosHandler, 
                listaArmas = listaCajados, 
                index = 0,
                classesPermitidas = new List<string> { "Mago", "Bruxo", "Feiticeiro", "Clerigo", "Druida" },
                Clicks = Cajados_Click
            }},
            { "machado", new ArmaData { 
                handler = MachadosHandler, 
                listaArmas = listaMachado, 
                index = 0,
                classesPermitidas = new List<string> { "Barbaro", "Guerreiro", "Paladino" },
                Clicks = Machados_Click
            }},
            { "martelo", new ArmaData { 
                handler = MartelosHandler, 
                listaArmas = listaMartelos, 
                index = 0,
                classesPermitidas = new List<string> { "Barbaro", "Guerreiro", "Paladino" },
                Clicks = Martelos_Click
            }},
            { "arco", new ArmaData { 
                handler = ArcosHandler, 
                listaArmas = listaArco, 
                index = 0,
                classesPermitidas = new List<string> { "Ranger", "Ladino" },
                Clicks = Arcos_Click
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

    // Método para atualizar as restrições baseadas na classe
    private void AtualizarRestricoesClasses()
    {
        string classeAtual = Render_Arma.Classes;
        
        foreach (var arma in armasData.Values)
        {
            if (arma.handler != null)
            {
                Button botao = arma.handler.GetComponent<Button>();
                Image imagem = arma.handler.GetComponent<Image>();
                Button btn = arma.Clicks.GetComponent<Button>();
                
                bool classePermitida = arma.classesPermitidas.Contains(classeAtual);
                
                // Configurar interatividade do botão
                if (botao != null)
                {
                    botao.interactable = classePermitida;
                }
                
                // Escurecer o handler se não for permitido
                Color32 corNormal = new Color32(80, 80, 80, 255); // R,G,B,A
                ColorBlock cb = btn.colors;  // pega as cores atuais do botão
                if(!classePermitida) {
                    cb.normalColor = corNormal;
                }    // altera apenas o Normal Color
                else
                {
                    cb.normalColor = new Color32(255, 255, 255, 255);
                }
                btn.colors = cb;                 
                
                // Escurecer também o texto se existir
                TextMeshProUGUI texto = arma.handler.transform.Find("TextoHandler")?.GetComponent<TextMeshProUGUI>();
                if (texto != null)
                {
                    Color corTexto = texto.color;
                    corTexto.a = classePermitida ? 1f : 0.4f;
                    texto.color = corTexto;
                }
            }
        }
    }

    // Método para verificar se uma arma é permitida para a classe atual
    private bool ArmaPermitida(string tipoArma)
    {
        if (armasData.ContainsKey(tipoArma))
        {
            string classeAtual = Render_Arma.Classes;
            return armasData[tipoArma].classesPermitidas.Contains(classeAtual);
        }
        return false;
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
        player = DadosJogador.Instance_jogador.playerData;
        player.weapons = new string[1]; 
        player.weapons[0] =GetTipoArmaPasta(armaAtual)+"."+armaSelecionada.nome;
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
                    "banjo" => "Banjos",
                    _ => "Espadas"
                };
        }
        return "Espadas";
    }

    public void AtivarArma(string tipoArma)
    {
        // Verificar se a arma é permitida para a classe atual
        if (!ArmaPermitida(tipoArma))
        {
            return;
        }

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

    // Métodos públicos para os botões (com verificação de permissão)
    public void Botao_espada() => AtivarArma("espada");
    public void Botao_banjo() => AtivarArma("banjo");
    public void Botao_cajado() => AtivarArma("cajado");
    public void Botao_machado() => AtivarArma("machado");
    public void Botao_martelo() => AtivarArma("martelo");
    public void Botao_arco() => AtivarArma("arco");

    // Método para obter a lista de armas permitidas
    public List<string> GetArmasPermitidas()
    {
        List<string> armasPermitidas = new List<string>();
        string classeAtual = Render_Arma.Classes;
        
        foreach (var arma in armasData)
        {
            if (arma.Value.classesPermitidas.Contains(classeAtual))
            {
                armasPermitidas.Add(arma.Key);
            }
        }
        
        return armasPermitidas;
    }
}