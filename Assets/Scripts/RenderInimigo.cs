using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;
using TipagemClasses;

public class RenderInimigo : MonoBehaviour
{
    public string Classes;
    public static RenderInimigo inimigo;
    public string Sexo;
    public string Raca;
    public GameObject prefab;
    public PlayerData_Json player;
    public PlayerData_SO playerData;
    public GameObject newCharacter;
    public GameObject back;
    public GameObject vida;
    private Material material;
    public Arma_ataque ar_at;
    private Animator animator;
    public List<string> lista_classes;
    public List<string> lista_sexos = new List<string>{"Homem", "Mulher"};
    public DndClassesData tipagemClasses;
    public List<string> lista_Raca = new List<string>{"Humano", "Orc", "Demonio", "Morte"};

    void Awake()
    {
        inimigo = this;
        playerData = ScriptableObject.CreateInstance<PlayerData_SO>();
    }
    void Start()
    {
        material = Resources.Load<Material>($"Cor/cores");

        string path = Path.Combine(Application.persistentDataPath, "Player.json");

        if (!File.Exists(path))
        {
            Debug.LogError("Arquivo Player.json não encontrado em: " + path);
        }
        player = new PlayerData_Json();
        System.Random random = new System.Random();


        player.characterClass = random.Next(0, 11);
        player.gender = random.Next(0, 1);
        player.race = random.Next(0, 3);

        playerData.name = player.name;

        playerData.characterClass = player.characterClass;
        playerData.subclass = player.subclass;
        playerData.subclass_traits = player.subclass_traits;
        playerData.spells = player.spells;
        playerData.is_summoner = player.is_summoner;

        playerData.race = player.race;
        playerData.gender = player.gender;
        playerData.color = player.color;

        playerData.talents = player.talents;
        playerData.weapons = player.weapons;
        playerData.attack_effect = player.attack_effect;

        playerData.sabedoria = player.sabedoria;
        playerData.inteligencia = player.inteligencia;
        playerData.carisma = player.carisma;
        playerData.forca = player.forca;
        playerData.contituicao = player.contituicao;
        playerData.destreza = player.destreza;
        playerData.hp = player.hp;
        HP life = vida.GetComponent<HP>();
        life.Inicializar(15);
        /*GameObject request = Resources.Load<GameObject>(
            $"Caracters/{lista_Raca[player.race]}/{lista_sexos[player.gender]}/{lista_classes[player.characterClass]}/{lista_classes[player.characterClass]}"
        );*/
        GameObject request = Resources.Load<GameObject>(
            $"Caracters/{lista_Raca[0]}/{lista_sexos[0]}/{lista_classes[0]}/{lista_classes[0]}"
        );
        Quaternion rotation = Quaternion.Euler(90, 0, 0);
        newCharacter = Instantiate(request, prefab.transform.position, rotation, prefab.transform);
        GameObject corpo = null;
        Transform corpoTransform = newCharacter
            .GetComponentsInChildren<Transform>(true)
            .FirstOrDefault(t => t.CompareTag("Corpo"));

        if (corpoTransform == null)
        {
            Debug.LogError("Objeto com a tag 'Corpo' não encontrado no prefab!");
        }
        else
        {
            corpo = corpoTransform.gameObject;
        }
        BoxCollider box = corpo.GetComponent<BoxCollider>();
        if (box == null)
            box = corpo.AddComponent<BoxCollider>();

        box.center = new Vector3(0.11f, 0.28f, 0f);
        box.size   = new Vector3(0.9f, 1.0f, 2f);
        Rigidbody rb = corpo.GetComponent<Rigidbody>();
        if (rb == null)
            rb = corpo.AddComponent<Rigidbody>();

        rb.mass = 1f;
        rb.linearDamping  = 0f;           // Linear Damping
        rb.angularDamping  = 0f;    // Angular Damping
        rb.useGravity = false;
        rb.isKinematic = false;
        SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);
        material = Resources.Load<Material>($"Cor/cores");
        Rigidbody rb1 = newCharacter.GetComponent<Rigidbody>();
        rb1.constraints = RigidbodyConstraints.FreezeAll;
        /*foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = material;
        }*/
        // -----------------------------------
        // ARMA
        // -----------------------------------
        
        //string[] armaRender = player.weapons[0].Split(".");
        //GameObject armaPrefab = Resources.Load<GameObject>($"Items/Armas/" + armaRender[0] + "/" + armaRender[1] + "/" + armaRender[1]);

        Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");

        //GameObject arma = Instantiate(armaPrefab, maoEsquerda);

        //arma.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
        
        // --- CORREÇÃO: PREVENIR PLAYER FICAR PRETO ---

        // -----------------------------------
        // ROTACIONAR PREFAB
        // -----------------------------------

        Vector3 newRotation = prefab.transform.eulerAngles;
        newRotation.z = 180f;
        prefab.transform.eulerAngles = newRotation;

        prefab.transform.eulerAngles = new Vector3(
            prefab.transform.eulerAngles.x,
            prefab.transform.eulerAngles.y,
            180f
        );
        ar_at = FindFirstObjectByType<Arma_ataque>();
        animator = GetComponent<Animator>();

    }
    public void Ataque()
    {
        ar_at.ataque = true;
        animator.SetBool("ataque-1", true);
        StartCoroutine(Resetar("ataque-1", 0.5f));

    }

    IEnumerator Resetar(string nomeDaVariavel, float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);

        if (animator.GetBool(nomeDaVariavel))
        {
            animator.SetBool(nomeDaVariavel, false);
            yield return new WaitForSeconds(tempoDeEspera);
            ar_at.ataque = false;
        }
    }
}
