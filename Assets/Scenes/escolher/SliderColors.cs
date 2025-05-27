using UnityEngine;
using UnityEngine.UI;

public class SliderColors : MonoBehaviour
{
    private Slider mySlider;
    public AgregarCor agrega;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySlider = GetComponent<Slider>();
        // Registra o evento de mudança de valor
        mySlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        Debug.Log("Novo valor do slider: " + value);
        // Aqui você pode usar o valor como quiser
    }
}
