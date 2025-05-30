using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Personagens : MonoBehaviour
{
    public string Classes;
    public string Sexo;
    public string Raca;
    public GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Classes = "Barbaro";
        Sexo = "Homem";
        Raca = "Humano";
        ResourceRequest request = Resources.LoadAsync<GameObject>($"{Raca}/{Sexo}/{Classes}/{Classes}.pdb");
        Debug.Log($"{Raca}/{Sexo}/{Classes}/{Classes}");
        GameObject newCharacter = Instantiate(request.asset as GameObject, Vector3.zero, Quaternion.identity);
        prefab = newCharacter;
    }
    public void Mudar()
    {

    }
    public void Desaparecer()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
