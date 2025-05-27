using UnityEngine;

public class Cores : MonoBehaviour
{
    private SpriteRenderer sprite;
    public AgregarCor agragador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void MudarCor()
    {
        sprite.color = agragador.corAtual;
    }
}
