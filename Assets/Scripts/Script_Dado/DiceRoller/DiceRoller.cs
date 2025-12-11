using UnityEngine;
using Utilities;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[RequireComponent(typeof(DiceSides))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class DiceRoller : MonoBehaviour {
    [Header("Dice Rolling Settings")]
    public SomDados sound;
    [SerializeField] float rotationSpeed = 680f; // Graus por segundo
    [SerializeField] float maxRollTime = 2f; // 2 segundos como solicitado
    [SerializeField] float smoothTime = 0.1f;
    public int result_face =1;
    private int number;
    [Header("UI References")]
    [SerializeField] TMPro.TextMeshProUGUI resultText;

    [Header("Audio & Particle Effects")]
    [SerializeField] AudioClip shakeClip;
    [SerializeField] AudioClip rollClip;
    [SerializeField] AudioClip finalResultClip;
    [SerializeField] GameObject finalResultEffect;
    private string Face_escolhida;
    List<int> faces = new List<int>
    {
        19, 19, 11, 7, 5, 16, 14, 10, 2, 6,
        6, 15, 12, 1, 13, 8, 20, 3, 17, 4, 18
    };
    DiceSides diceSides;
    AudioSource audioSource;
    Rigidbody rb;

    CountdownTimer rollTimer;
    
    Vector3 originPosition;
    Vector3 currentVelocity;
    bool finalize;
    Vector3 randomRotationAxis;

    void Awake() {
        diceSides = GetComponent<DiceSides>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        originPosition = transform.position;
        
        // Congelar posição e rotação para manter fixo nos eixos X e Y
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | 
                        RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | 
                        RigidbodyConstraints.FreezeRotationY;
        
        rollTimer = new CountdownTimer(maxRollTime);
        rollTimer.OnTimerStart += PerformRotation;
        rollTimer.OnTimerStop += () => finalize = true;
    }

    public string Rolar() {
        if (rollTimer.IsRunning) return "";
        sound.PlaySomRolando();
        rollTimer.Start();
        System.Random random = new System.Random();
        number = random.Next(0, 19);
        Face_escolhida = faces[number].ToString();
        return Face_escolhida;

    }

    void Update() {
        rollTimer.Tick(Time.deltaTime);

        if (rollTimer.IsRunning && !finalize) {
            // Aplicar rotação contínua durante o roll
            RotateDice();
        }

        if (finalize) {
            FinalizeRoll();
        }
    }

    void PerformRotation() {
        ResetDiceState();
        resultText.text = "";
        
        // Gerar um eixo de rotação aleatório (apenas no eixo Z permitido)
        randomRotationAxis = new Vector3(0, 0, Random.Range(-1f, 1f)).normalized;
        
        audioSource.clip = rollClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void RotateDice() {
        // Aplicar rotação usando o Rigidbody (mais suave e físico)
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.AngleAxis(rotationThisFrame, randomRotationAxis);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void FinalizeRoll() {
        rollTimer.Stop();
        finalize = false;
        
        // Parar completamente qualquer movimento residual
        rb.angularVelocity = Vector3.zero;
        
        audioSource.loop = false;
        audioSource.Stop();
        audioSource.PlayOneShot(finalResultClip);
        
        //var particles = InstantiateFX(finalResultEffect, transform.position, 5f);
        //Destroy(particles, 3f);
        
        resultText.text = Face_escolhida;
        
        // Opcional: Girar o dado para mostrar a face 2 fisicamente
        ShowFace2(number);
        sound.PlaySomFinalizando();
    }
    void ShowFace2(int f) {
        // Encontra e aplica a rotação da face 2
        for (int i = 0; i < diceSides.Sides.Length; i++) {
            if (diceSides.Sides[i].Value == f) {
                transform.rotation = diceSides.GetWorldRotationFor(i);
                break;
            }
        }
    }
    void ResetDiceState() {
        rb.angularVelocity = Vector3.zero;
        transform.position = originPosition;
        // Resetar para rotação inicial se necessário
        // transform.rotation = Quaternion.identity;
    }
    
    GameObject InstantiateFX(GameObject fx, Vector3 position, float size) {
        var particles = Instantiate(fx, position, Quaternion.identity);
        particles.transform.localScale = Vector3.one * size;
        return particles;
    }
}