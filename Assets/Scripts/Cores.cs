using UnityEngine;

public class Cores : MonoBehaviour
{
    public AgregarCor agragador;
    public SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite.color = new Color(45.0f, 120.0f, 04.0f);
                // Verifica se o agregador foi atribuído e se inscreve no evento
        if (agragador != null)
        {
            agragador.OnCorAlterada += AtualizarCor; // se inscreve no evento
        }

    }
    private void AtualizarCor(Color novaCor)
    {
       GetComponent<SpriteRenderer>().color = novaCor;
    }
}
