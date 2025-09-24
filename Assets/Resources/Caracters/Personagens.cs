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
        GameObject request = Resources.Load<GameObject>($"Caracters/{Raca}/{Sexo}/{Classes}/{Classes}");
        if (request == null)
        {
            Debug.Log("passando aqui");
        }
        // Instancia o novo personagem como filho do prefab
        GameObject newCharacter = Instantiate(request, prefab.transform);

        //Arma
        //newCharacter.transform.localPosition = Vector3.zero; // Posiciona no centro do pai
        newCharacter.transform.localRotation = Quaternion.identity;
        SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = material;
        }
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
        GameObject armaPrefab = Resources.Load<GameObject>($"Items/Armas/Espadas/Espada-1/espada1");
        if (armaPrefab != null)
        {
            // Supondo que dentro do personagem existe um "ponto de ancoragem"
            Transform maoEsquerda = newCharacter.GetComponentsInChildren<Transform>(true).FirstOrDefault(t => t.name == "Mao_Esquerda(Slot)");
            Debug.Log(maoEsquerda.transform);
            if (maoEsquerda != null)
            {
                GameObject arma = Instantiate(armaPrefab, maoEsquerda); // já fica aninhado
                arma.transform.localPosition = new Vector3(0.2f, 1.0f, 0f);
                arma.transform.localRotation = Quaternion.identity;
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
