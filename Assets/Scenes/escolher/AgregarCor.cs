using UnityEngine;

public class AgregarCor : MonoBehaviour
{
    public Cores[] objetos;
    public float r;
    public float g;
    public float b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    void MudancadeCor()
    {
        foreach (Cores obj in objetos) {
            obj.MudarCor();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
