using UnityEngine;

public class Upar : MonoBehaviour
{
    public GameObject linhasRetas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void AtivarLinha()
    {
        StartCoroutine(DelayAtivar());
    }

    private System.Collections.IEnumerator DelayAtivar()
    {
        linhasRetas.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        linhasRetas.SetActive(false);
    }
    public void UpCarisma()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;

        // Define um gradiente entre amarelo e laranja
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.yellow, 0.0f), new GradientColorKey(new Color(1f, 0.5f, 0f), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 1.0f) }
        );

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);  
        AtivarLinha();  
    }
    public void UpForca()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;

        // Agora você pode alterar propriedades de start
        main.startSize = 1.5f; // Exemplo: muda o tamanho inicial das partículas
        main.startColor = Color.red; // Exemplo: muda a cor inicial das partículas
        main.startLifetime = 2.0f; // Exemplo: muda o tempo de vida das partículas 
        AtivarLinha(); 
    }
    public void UpInteligencia()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;

        // Define um gradiente entre amarelo e roxo
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),           // início: amarelo
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 1.0f) // fim: roxo (RGB 128, 0, 128)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),  // totalmente visível no início
                new GradientAlphaKey(1f, 1.0f)   // totalmente visível no fim
            }
        );

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);    
        AtivarLinha();
    }
    public void UpConstituicao()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;
        // Define um gradiente amarelo -> roxo -> rosa
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),           // início: amarelo
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0.6f), // meio: roxo
                new GradientColorKey(new Color(1f, 0.4f, 0.8f), 1.0f)  // fim: rosa (RGB 255, 102, 204)
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),  // totalmente visível no início
                new GradientAlphaKey(1f, 1.0f)   // totalmente visível no fim
            }
        );

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);   
        AtivarLinha();     
    }
    public void UpSabedoria()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;
        // Define um gradiente amarelo -> verde -> roxo -> rosa
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),             // início: amarelo
                new GradientColorKey(Color.green, 0.3f),              // meio: verde
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0.6f),// roxo
                new GradientColorKey(new Color(1f, 0.4f, 0.8f), 1.0f) // fim: rosa
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),  // totalmente visível no início
                new GradientAlphaKey(1f, 1.0f)   // totalmente visível no fim
            }
        );

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);  
        AtivarLinha();      
    }
    public void UpDestreza()
    {
        linhasRetas.SetActive(true);
        ParticleSystem p = linhasRetas.GetComponent<ParticleSystem>();
        // Pega o módulo Main
        // Pega o módulo Main
        ParticleSystem.MainModule main = p.main;
        // Define um gradiente amarelo -> verde -> roxo -> rosa
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] {
                new GradientColorKey(Color.yellow, 0.0f),             // início: amarelo
                new GradientColorKey(Color.green, 0.3f),              // meio: verde
                new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0.6f),// roxo
                new GradientColorKey(new Color(1f, 0.4f, 0.8f), 1.0f) // fim: rosa
            },
            new GradientAlphaKey[] {
                new GradientAlphaKey(1f, 0.0f),  // totalmente visível no início
                new GradientAlphaKey(1f, 1.0f)   // totalmente visível no fim
            }
        );

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);

        // Aplica o gradiente como startColor
        main.startColor = new ParticleSystem.MinMaxGradient(gradient);        
        AtivarLinha();
    }

}
