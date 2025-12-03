using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RenderPlayer : MonoBehaviour
{
    public string Classes;
    public string Sexo;
    public string Raca;
    public GameObject prefab;
    public GameObject newCharacter;
    public Material material;
    private PlayerData_SO player;
    public List<string> lista_classes = new List<string>{"Barbaro","Bardo","Bruxo","Clerigo","Druida","Feiticeiro","Guerreiro","Ladino","Monge","Mago","Paladino","Ranger"   };
    public List<string> lista_sexos = new List<string>{"Homem", "Mulher"};
    public List<string> lista_Raca = new List<string>{"Humano", "Orc", "Demonio", "Morte"};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = DadosJogador.Instance_jogador.playerData;
        Classes = lista_classes[player.characterClass];
        Sexo = lista_sexos[player.gender];
        Raca = lista_Raca[player.race];
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
        string[] espadas_machados_martelos = { $"Items/Armas/Espadas/Espada-1/Espada-1", $"Items/Armas/Espadas/Espada-2/Espada-2", $"Items/Armas/Espadas/Espada-3/Espada-3" };

        GameObject armaPrefab;
        // 2. Gere um índice aleatório dentro do intervalo do array
        int index = UnityEngine.Random.Range(0, espadas_machados_martelos.Length);
        armaPrefab = Resources.Load<GameObject>(espadas_machados_martelos[index]);
        Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");
        GameObject arma = Instantiate(armaPrefab, maoEsquerda); // já fica aninhado
        //arma.transform.localPosition = new Vector3(-0.64f, -0.7f, 0f);
        arma.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

        SpriteRenderer sr = arma.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingOrder = 3;
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
