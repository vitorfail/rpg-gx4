using UnityEngine;

public class CentralizarPivo : MonoBehaviour
{
    [ContextMenu("Ajustar tamanho ao filho com tag 'Arma'")]
    void AjustarTamanho()
    {
        // Procura recursivamente o filho com tag "Arma"
        Transform filho = EncontrarFilhoComTagRecursivo(transform, "Arma");
        if (filho == null)
        {
            Debug.LogWarning("Nenhum filho com a tag 'Arma' encontrado!");
            return;
        }

        Renderer filhoRenderer = filho.GetComponent<Renderer>();
        Renderer paiRenderer = GetComponent<Renderer>();

        if (filhoRenderer == null || paiRenderer == null)
        {
            Debug.LogWarning("Renderers não encontrados no pai ou filho!");
            return;
        }

        // Calcula os bounds do filho
        Bounds boundsFilho = filhoRenderer.bounds;

        // Ajusta a escala do pai para o tamanho do filho
        Vector3 tamanhoFilho = boundsFilho.size;
        Vector3 tamanhoAtualPai = paiRenderer.bounds.size;

        Vector3 novaEscala = transform.localScale;
        novaEscala.x *= tamanhoFilho.x / tamanhoAtualPai.x;
        novaEscala.y *= tamanhoFilho.y / tamanhoAtualPai.y;
        novaEscala.z *= tamanhoFilho.z / tamanhoAtualPai.z;

        transform.localScale = novaEscala;

        Debug.Log("Tamanho do pai ajustado para o filho: " + filho.name);
    }

    Transform EncontrarFilhoComTagRecursivo(Transform parent, string tag)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag(tag))
                return child;

            Transform resultado = EncontrarFilhoComTagRecursivo(child, tag);
            if (resultado != null)
                return resultado;
        }
        return null;
    }
}