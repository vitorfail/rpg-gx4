using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Newtonsoft.Json;
using TipagemClasses;
public class Personagens : MonoBehaviour
{
    public string Classes;
    public string Sexo;
    public string Raca;
    public GameObject prefab;
    public GameObject newCharacter;
    public Material material;
    public Button botao_sexo;
    public Sprite mulherOffSprite; 
    private PlayerData_SO player;
    public Sprite mulherOn;  
    public TextAsset jsonclasses;
    private DndClassesData jsontipagem;
    private List<string> lista_classes;
    public List<string> lista_sexos = new List<string>{"Homem", "Mulher"};
    public List<string> lista_Raca = new List<string>{"Humano", "Orc", "Demonio", "Morte"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jsontipagem = JsonConvert.DeserializeObject<DndClassesData>(jsonclasses.text);
        lista_classes = jsontipagem.Classes.Keys.ToList();

        player = DadosJogador.Instance_jogador.playerData;
        Classes = lista_classes[player.characterClass];
        Sexo = lista_sexos[player.gender];
        Raca = lista_Raca[player.race];
        Mudar();
    }
    public void Mudar()
    {
        if(Raca == "Morte" && Sexo == "Mulher")
        {
            Sexo ="Homem";
        }
        if(Raca == "" || Classes== "")
        {
            return;
        }
        if(Raca == "Morte")
        {
            botao_sexo.image.sprite = mulherOffSprite; ;
            botao_sexo.interactable  =false;
        }
        else
        {
            botao_sexo.image.sprite = mulherOn; ;
            botao_sexo.interactable  =true;
        }
        if (prefab.transform.childCount > 0)
        {
            foreach (Transform child in prefab.transform)
            {
                Destroy(child.gameObject);
            }
        }
        player.characterClass= lista_classes.IndexOf(Classes);
        player.gender = lista_sexos.IndexOf(Sexo);
        player.race = lista_Raca.IndexOf(Raca);
        GameObject request = Resources.Load<GameObject>($"Caracters/{lista_Raca[player.race]}/{lista_sexos[player.gender]}/{lista_classes[player.characterClass]}/{lista_classes[player.characterClass]}");
        // Instancia o novo personagem como filho do prefab
        newCharacter = Instantiate(request, prefab.transform);
        SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = material;
        }
        GameObject armaPrefab = null;
        if (Classes == "Barbaro" || Classes == "Guerreiro" || Classes == "Paladino" || Classes == "Barbaro")
        {
            string[] espadas_machados_martelos = { $"Items/Armas/Espadas/Espada-1/Espada-1", $"Items/Armas/Espadas/Espada-2/Espada-2", $"Items/Armas/Espadas/Espada-3/Espada-3" };

            // 2. Gere um índice aleatório dentro do intervalo do array
            int index = UnityEngine.Random.Range(0, espadas_machados_martelos.Length);
            armaPrefab = Resources.Load<GameObject>(espadas_machados_martelos[index]);
        }
        if (Classes=="Mago"|| Classes=="Druida" || Classes=="Bruxo"|| Classes=="Feiticeiro"|| Classes=="Clerigo")
        {
            string[] cajados = { $"Items/Armas/Cajados/Cajado-1/Cajado-1", $"Items/Armas/Cajados/Cajado-2/Cajado-2", $"Items/Armas/Cajados/Cajado-3/Cajado-3",$"Items/Armas/Cajados/Cajado-4/Cajado-4" };

            // 2. Gere um índice aleatório dentro do intervalo do array
            int index = UnityEngine.Random.Range(0, cajados.Length);

            armaPrefab = Resources.Load<GameObject>(cajados[index]);
        }
        if (armaPrefab != null)
        {
            // Supondo que dentro do personagem existe um "ponto de ancoragem"
            Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");
            if (maoEsquerda != null)
            {
                GameObject arma = Instantiate(armaPrefab, maoEsquerda); // já fica aninhado
                //arma.transform.localPosition = new Vector3(-0.64f, -0.7f, 0f);
                arma.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

                SpriteRenderer sr = arma.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingOrder = 3;
                }
            }
        }
    }
    // Update is called once per frame
    public void Render_Arma(string v){
        
        GameObject armaPrefab = null;
        armaPrefab = Resources.Load<GameObject>($""+v);


        Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");
        if (maoEsquerda.childCount > 0)
        {
            Transform armaAntiga = maoEsquerda.GetChild(0);
            Destroy(armaAntiga.gameObject);
        }
            if (maoEsquerda != null)
            {
                GameObject arma = Instantiate(armaPrefab, maoEsquerda); // já fica aninhado
                //arma.transform.localPosition = new Vector3(-0.64f, -0.7f, 0f);
                arma.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

                SpriteRenderer sr = arma.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sortingOrder = 3;
                }
            }
    }

}
