using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Newtonsoft.Json;

public class PlayerManager  : MonoBehaviour
{
    private bool isEscolher;
    private Animator animator;
    public Arma_ataque ar_at;

    private float autoAttackTimer = 0f;
    private float autoAttackInterval = 4f; // ataque automático a cada 4 segundos
    void Start()
    {   
        isEscolher = SceneManager.GetActiveScene().name == "Customization";
        if(isEscolher){
            ar_at = FindFirstObjectByType<Arma_ataque>();
            animator = GetComponent<Animator>();

            if (animator == null)
            {
                Debug.LogError("⚠️ Nenhum Animator encontrado no objeto Player!");
            }
        }
    }

    void Update()
    {
        if (isEscolher)
        {
            // Incrementa o timer
            autoAttackTimer += Time.deltaTime;

            // Se já passou o intervalo, realiza ataque automático
            if (autoAttackTimer >= autoAttackInterval)
            {
                Ataque();
            }
        }
    }

    void OnMouseDown()
    {
        if (isEscolher)
        {
            Ataque(); // Ataque manual ao clicar
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Espada"))
        {
            animator.SetBool("dano", true);
            StartCoroutine(Resetar("dano", 0.5f));

            // Reinicia o timer apenas para ataque automático
            autoAttackTimer = 0f;
        }
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
