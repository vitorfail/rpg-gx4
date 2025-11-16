using UnityEngine;

public class Mover_inicial : MonoBehaviour
{   
    public GameObject nivel;
    public GameObject atributos;
    public GameObject Player;
    public GameObject Armas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        atributos.SetActive(true);
        Armas.SetActive(false);   
    }
    public void Mover_1()
    {
        atributos.SetActive(false);
        Armas.SetActive(true);
    }
}
