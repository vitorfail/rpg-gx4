using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Personagens : MonoBehaviour
{
    public string Classes;
    public string Sexo;
    public string Raca;
    public GameObject prefab;
    public Material material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Classes = "Barbaro";
        Sexo = "Homem";
        Raca = "Humano";
        Mudar();
    }
    public void Mudar()
    {
        if (prefab.transform.childCount > 0)
        {
            foreach (Transform child in prefab.transform)
            {
                Destroy(child.gameObject);
            }
        }
        GameObject request = Resources.Load<GameObject>($"Caracters/{Raca}/{Sexo}/{Classes}/{Classes}");
        // Instancia o novo personagem como filho do prefab
        GameObject newCharacter = Instantiate(request, prefab.transform);
        SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = material;
        }
        GameObject armaPrefab = null;
        if (Classes == "Barbaro" || Classes == "Guerreiro" || Classes == "Paladino" || Classes == "Barbaro")
        {
            string[] espadas_machados_martelos = { $"Items/Armas/Espadas/Espada-1/espada1", $"Items/Armas/Espadas/Espada-1/espada1", $"Items/Armas/Espadas/Espada-1/espada1" };

            // 2. Gere um índice aleatório dentro do intervalo do array
            int index = UnityEngine.Random.Range(0, espadas_machados_martelos.Length);
            armaPrefab = Resources.Load<GameObject>(espadas_machados_martelos[index]);
        }
        if (Classes=="Mago"|| Classes=="Druida" || Classes=="Bruxo"|| Classes=="Feiticeiro"|| Classes=="Clerigo")
        {
            string[] cajados = { $"Items/Armas/Cajados/Cajado-1/cajado1", $"Items/Armas/Cajados/Cajado-2/cajado2", $"Items/Armas/Cajados/Cajado-3/cajado3",$"Items/Armas/Cajados/Cajado-4/cajado4" };

            // 2. Gere um índice aleatório dentro do intervalo do array
            int index = UnityEngine.Random.Range(0, cajados.Length);

            armaPrefab = Resources.Load<GameObject>(cajados[index]);
        }
        if (armaPrefab != null)
        {
            // Supondo que dentro do personagem existe um "ponto de ancoragem"
            Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao-Esquerda(Slot)");
            Debug.Log(maoEsquerda.transform);
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
            else
            {
                Debug.Log("testando");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
