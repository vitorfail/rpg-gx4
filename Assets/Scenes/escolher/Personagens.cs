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
        Classes = "Barbaro";
        Sexo = "Homem";
        Raca = "Humano";
        GameObject objetoComTag = personagens.FirstOrDefault(go => go.CompareTag(Classes + "_" + Sexo + "_" + Raca));
        Transform trans = objetoComTag.GetComponent<Transform>();
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);

    }
    public void Mudar()
    {
        GameObject objetoComTag = personagens.FirstOrDefault(go => go.CompareTag(Classes + "_" + Sexo + "_" + Raca));
        Transform trans = objetoComTag.GetComponent<Transform>();
        trans.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    public void Desaparecer()
    {
        GameObject objetoComTag = personagens.FirstOrDefault(go => go.CompareTag(Classes + "_" + Sexo + "_" + Raca));
        Transform trans = objetoComTag.GetComponent<Transform>();
        trans.localScale = new Vector3(0f, 0f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
