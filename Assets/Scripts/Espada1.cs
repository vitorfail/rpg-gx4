using UnityEngine;
using UnityEngine.VFX;

public class Espada1 : MonoBehaviour
{
    // Referência ao script que tem a variável Arma_ataque
    public Arma_ataque ar_at;

    // Arrays para armazenar todos os efeitos do objeto
    private VisualEffect[] particleSystems;
    private TrailRenderer[] trailRenderers;
    public VisualEffect[] visualEffects; // Novo array para Visual Effect Graphs

    void Start()
    {
        Debug.Log("Adicionando denovo");
        // Procura automaticamente o controlador na cena
        ar_at = FindFirstObjectByType<Arma_ataque>();
        if (ar_at == null || ar_at == false)
        {
            Debug.LogWarning("Nenhum objeto com 'SeuScript' encontrado na cena!");
            return;
        }
        
        // Pega todos os ParticleSystems, TrailRenderers e Visual Effects dentro deste GameObject e filhos
        particleSystems = GetComponentsInChildren<VisualEffect>(true);
        trailRenderers = GetComponentsInChildren<TrailRenderer>(true);

        // Desativa todos os efeitos no início
        foreach (var ps in particleSystems)
        {
            ps.Stop();
        }

        foreach (var tr in trailRenderers)
        {
            tr.enabled = false;
        }

        foreach (var vfx in visualEffects)
        {
            vfx.Stop();
        }

        ar_at.OnAtaqueMudou += OnAtaqueMudou;
        OnAtaqueMudou(ar_at.ataque);
        if (ar_at.ataque)
        {
            ar_at.ataque = false;
        }
    }
    
    void OnDestroy()
    {
        if (ar_at != null)
            ar_at.OnAtaqueMudou -= OnAtaqueMudou;
    }
    
    private void OnAtaqueMudou(bool ativo)
    {
        Ativar(ativo);
    }
    
    private void Ativar(bool ativo)
    {
        if (ar_at == null || ar_at == false) return;

        bool armaAtiva = ar_at.ataque;

        // Ativa ou desativa efeitos dependendo da variável
        foreach (var ps in particleSystems)
        {
            if (armaAtiva)
            {
                ps.Play();
            }
            else
            {
                ps.Stop();
            }
        }

        foreach (var tr in trailRenderers)
        {
            tr.enabled = armaAtiva;
        }

        foreach (var vfx in visualEffects)
        {
            if (armaAtiva)
            {
                vfx.Play();
            }
            else
            {
                vfx.Stop();
            }
        }
    }
}