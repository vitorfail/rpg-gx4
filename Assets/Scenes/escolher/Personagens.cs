using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Personagens : MonoBehaviour
{
    public string Classes;
    public string Sexo;
    public string Raca;
    public List<GameObject> personagens;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Classes = "Bárbaro";
        Sexo = "Homem";
        Raca = "Humano";
        GameObject objetoComTag = personagens.FirstOrDefault(go => go.CompareTag(Classes+"_"+Sexo+"_"+Raca));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
