using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using TipagemClasses;
using System;

public class RenderSubclasse : MonoBehaviour
{
    public GameObject container;
    public TextAsset json_class;
    public DndClassesData clastipagem;
    public Personagens person;
    public ClassDetails arquetipo;
    public TMP_FontAsset fontTMP;
    public TextMeshProUGUI nome_subclasse;
    public TextMeshProUGUI nome_descri;

    private List<Button> allButtons = new List<Button>(); // guarda todos os botões criados

    void OnEnable()
    {   ClearGrid();
        clastipagem = JsonConvert.DeserializeObject<DndClassesData>(json_class.text);
        if(person.Classes.ToLower() != null && person.Classes.ToLower() != "")
        {
            arquetipo = clastipagem.Classes[person.Classes];
            foreach (var kv in arquetipo.Arquetipo)
            {
                string chave = kv.Key;
                Archetype arq = kv.Value;

                if (string.IsNullOrEmpty(arq.Nome))
                    continue;

                CreateButton(arq);
            }
            if (allButtons != null && allButtons.Count > 0)
            {
                allButtons[0].onClick.Invoke();
            }
        }

    }

    void CreateButton(Archetype arq)
    {
        GameObject btnObj = new GameObject("Btn_" + arq.Nome, typeof(RectTransform));
        btnObj.transform.SetParent(container.transform, false);

        Image img = btnObj.AddComponent<Image>();
        Sprite sprite = Resources.Load<Sprite>(arq.Img.Replace(".png", ""));
        if (sprite != null) img.sprite = sprite;
        img.raycastTarget = true;

        Button btn = btnObj.AddComponent<Button>();
        btn.onClick.AddListener(() => OnSubclasseClicked(btn, arq));

        // Adiciona o botão à lista
        allButtons.Add(btn);

        // ======== TEXTO ========
        GameObject txtObj = new GameObject("Text", typeof(RectTransform));
        txtObj.transform.SetParent(btnObj.transform, false);

        TextMeshProUGUI txt = txtObj.AddComponent<TextMeshProUGUI>();
        txt.text = "n";
        txt.fontSize = 1;
        txt.font = fontTMP;
        txt.alignment = TextAlignmentOptions.Center;
        txt.color = Color.white;

        RectTransform rt = btnObj.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.pivot = new Vector2(0.5f, 0.5f); // centraliza o pivot
        rt.anchoredPosition = Vector2.zero; // opcional, centraliza dentro do pai
        rt.sizeDelta = new Vector2(25, 20);

        RectTransform trt = txtObj.GetComponent<RectTransform>();
        trt.anchorMin = Vector2.zero;
        trt.anchorMax = Vector2.one;
        trt.offsetMin = Vector2.zero;
        trt.offsetMax = new Vector2(0, -150);
    }

    void OnSubclasseClicked(Button clickedButton, Archetype arq)
    {
        nome_subclasse.text = arq.Nome;
        nome_descri.text = arq.Text;

        // Desmarca todos os botões
        foreach (var btn in allButtons)
        {
            Image img = btn.GetComponent<Image>();
            if (img != null)
                img.color = Color.white; // cor padrão
        }

        // Marca o botão clicado
        Image clickedImg = clickedButton.GetComponent<Image>();
        if (clickedImg != null)
            clickedImg.color = Color.red;
    }
    void ClearGrid()
    {
        foreach (var btn in allButtons)
        {
            if (btn != null)
                Destroy(btn.gameObject);
        }

        allButtons.Clear();
    }
}
