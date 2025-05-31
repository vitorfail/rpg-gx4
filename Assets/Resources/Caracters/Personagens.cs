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
        Debug.Log($"Caracters/{Raca}/{Sexo}/{Classes}/{Classes}");
        GameObject request = Resources.Load<GameObject>($"Caracters/{Raca}/{Sexo}/{Classes}/{Classes}");
        // Instancia o novo personagem como filho do prefab
        GameObject newCharacter = Instantiate(request, prefab.transform);
        SpriteRenderer[] spriteRenderers = newCharacter.GetComponentsInChildren<SpriteRenderer>(true);

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.material = material;
        }
        //newCharacter.transform.localPosition = new Vector3(0f,0f,0f); // Posiciona no centro do pai
        //newCharacter.transform.localRotation = Quaternion.identity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
