using System.Collections.Generic;
using System.IO;
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
        string path = Path.Combine(Application.persistentDataPath, "Player.json");

        if (!File.Exists(path))
        {
            Debug.LogError("Arquivo Player.json não encontrado em: " + path);
        }

        string json = File.ReadAllText(path);
        PlayerData_Json player = JsonUtility.FromJson<PlayerData_Json>(json);
        Classes = lista_classes[player.characterClass];
        Sexo = lista_sexos[player.gender];
        Raca = lista_Raca[player.race];
        player.characterClass= lista_classes.IndexOf(Classes);
        player.gender = lista_sexos.IndexOf(Sexo);
        player.race = lista_Raca.IndexOf(Raca);
        Debug.Log($"Caracters/{lista_Raca[player.race]}/{lista_sexos[player.gender]}/{lista_classes[player.characterClass]}/{lista_classes[player.characterClass]}");
        GameObject request = Resources.Load<GameObject>($"Caracters/{lista_Raca[player.race]}/{lista_sexos[player.gender]}/{lista_classes[player.characterClass]}/{lista_classes[player.characterClass]}");
        // Instancia o novo personagem como filho do prefab
        Quaternion rotation = Quaternion.Euler(90, 0, 0);

        newCharacter = Instantiate(request, prefab.transform.position, rotation, prefab.transform);
        //SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);

//        foreach (SpriteRenderer renderer in spriteRenderers)
//        {
//            renderer.material = material;
//        }
//        string[] espadas_machados_martelos = { $"Items/Armas/Espadas/Espada-1/Espada-1", $"Items/Armas/Espadas/Espada-2/Espada-2", $"Items/Armas/Espadas/Espada-3/Espada-3" };

//        GameObject armaPrefab;
//        string[] armaRender = player.weapons[0].Split(".");
//        // 2. Gere um índice aleatório dentro do intervalo do array
//        armaPrefab = Resources.Load<GameObject>($"Items/Armas/"+armaRender[0]+"/"+armaRender[1]+"/"+armaRender[1]);
//        Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");
//        GameObject arma = Instantiate(armaPrefab, maoEsquerda); // já fica aninhado
//        //arma.transform.localPosition = new Vector3(-0.64f, -0.7f, 0f);
//        arma.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);

//        SpriteRenderer sr = arma.GetComponent<SpriteRenderer>();
//        if (sr != null)
//        {
//            sr.sortingOrder = 3;
//        }
    }
    // Update is called once per frame
}
