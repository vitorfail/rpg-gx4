using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

public class PlayerManager  : MonoBehaviour
{
    private Animator animator;
    public Arma_ataque ar_at;

    private float autoAttackTimer = 0f;
    private float autoAttackInterval = 4f; // ataque automático a cada 4 segundos
    void Start()
    {   
        ar_at = FindFirstObjectByType<Arma_ataque>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("⚠️ Nenhum Animator encontrado no objeto Player!");
        }
    }

    void Update()
    {
        // Incrementa o timer
        autoAttackTimer += Time.deltaTime;

        // Se já passou o intervalo, realiza ataque automático
        if (autoAttackTimer >= autoAttackInterval)
        {
            Ataque();
        }
    }

    void OnMouseDown()
    {
        Ataque(); // Ataque manual ao clicar
    }
    void Ataque()
    {
        ar_at.ataque = true;
        animator.SetBool("ataque-1", true);
        StartCoroutine(Resetar("ataque-1", 0.5f));

        // Reinicia o timer apenas para ataque automático
        autoAttackTimer = 0f;
    }

    IEnumerator Resetar(string nomeDaVariavel, float tempoDeEspera)
    {
        yield return new WaitForSeconds(tempoDeEspera);

        if (animator.GetBool(nomeDaVariavel))
        {
            animator.SetBool(nomeDaVariavel, false);
            yield return new WaitForSeconds(tempoDeEspera);
            ar_at.ataque = false;
        }
    }
}
