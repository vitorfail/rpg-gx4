using UnityEngine;

public class Atributos : MonoBehaviour
{
    public RectTransform rect;
    public float att;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Attr(float at)
    {
        rect.sizeDelta = new Vector2(at, rect.sizeDelta.y);
    }
}
