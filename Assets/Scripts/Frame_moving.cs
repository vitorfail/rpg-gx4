using UnityEngine;
using System.Collections;

public class UIMovement : MonoBehaviour
{
    [Header("Configurações dos Objetos UI")]
    [SerializeField] private RectTransform firstUIObject; // Primeiro objeto UI (sobe/desce)
    [SerializeField] private RectTransform secondUIObject; // Segundo objeto UI (desce/sobe)
    
    [Header("Configurações de Movimento")]
    [SerializeField] private float movementDistance = 10f; // Distância do movimento
    [SerializeField] private float movementSpeed = 2f; // Velocidade do movimento
    [SerializeField] private bool useUnscaledTime = false; // Usar Time.unscaledTime?

    private Vector2 firstOriginalPosition;
    private Vector2 secondOriginalPosition;
    private float timer;

    void OnEnable()
    {
        // Validação dos objetos
        if (firstUIObject == null || secondUIObject == null)
        {
            Debug.LogError("Por favor, atribua ambos os objetos UI no Inspector!");
            enabled = false;
            return;
        }

        // Guarda as posições originais
        firstOriginalPosition = firstUIObject.anchoredPosition;
        secondOriginalPosition = secondUIObject.anchoredPosition;
        
        // Reinicia o timer
        timer = 0f;
        
        // Opcional: Inicia na posição original para garantir consistência
        ResetPositions();
    }

    void OnDisable()
    {
        // Opcional: Resetar posições quando desabilitado
        ResetPositions();
    }

    void Update()
    {
        // Atualiza o timer
        float deltaTime = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        timer += deltaTime * movementSpeed;

        // Calcula o valor do seno para movimento suave (oscilação entre -1 e 1)
        float sinValue = Mathf.Sin(timer);

        // Converte para valor entre 0 e 1 para uso no Lerp
        float t = (sinValue + 1f) / 2f;

        // Movimenta o primeiro objeto (sobe/desce)
        Vector2 firstTargetUp = firstOriginalPosition + Vector2.up * movementDistance;
        Vector2 firstTargetDown = firstOriginalPosition + Vector2.down * movementDistance;
        
        // Interpola entre subir e descer
        Vector2 firstNewPosition = Vector2.Lerp(firstTargetDown, firstTargetUp, t);
        firstUIObject.anchoredPosition = firstNewPosition;

        // Movimenta o segundo objeto (desce/sobe) - movimento oposto
        Vector2 secondTargetUp = secondOriginalPosition + Vector2.up * movementDistance;
        Vector2 secondTargetDown = secondOriginalPosition + Vector2.down * movementDistance;
        
        // Interpola na direção oposta
        Vector2 secondNewPosition = Vector2.Lerp(secondTargetUp, secondTargetDown, t);
        secondUIObject.anchoredPosition = secondNewPosition;
    }

    // Métodos para controle manual
    public void ResetPositions()
    {
        if (firstUIObject != null && secondUIObject != null)
        {
            firstUIObject.anchoredPosition = firstOriginalPosition;
            secondUIObject.anchoredPosition = secondOriginalPosition;
            timer = 0f;
        }
    }

    public void SetMovementDistance(float newDistance)
    {
        movementDistance = newDistance;
    }

    public void SetMovementSpeed(float newSpeed)
    {
        movementSpeed = newSpeed;
    }

    // Método para recapturar posições atuais como originais
    public void CaptureCurrentPositionsAsOriginal()
    {
        if (firstUIObject != null && secondUIObject != null)
        {
            firstOriginalPosition = firstUIObject.anchoredPosition;
            secondOriginalPosition = secondUIObject.anchoredPosition;
        }
    }
}