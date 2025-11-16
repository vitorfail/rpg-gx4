using UnityEngine;
using UnityEngine.UI;

public class VisualCharacterCustomizer : MonoBehaviour
{
    // Variáveis para armazenar as seleções atuais
    private string currentClass = "Warrior";
    private string currentGender = "Male";
    private string currentRace = "Human";
    
    // Referência para a imagem do personagem
    public Image characterDisplay;
    
    // Todos os sprites possíveis (arraste no Inspector)
    public Sprite warriorMaleHuman;
    public Sprite warriorMaleElf;
    // ... adicione todos os outros sprites
    
    // Método para atualizar a exibição
    void UpdateCharacterDisplay()
    {
        string spriteKey = $"{currentClass}_{currentGender}_{currentRace}";
        
        // Você pode usar um switch ou um dicionário para mapear as combinações
        switch(spriteKey)
        {
            case "Warrior_Male_Human":
                characterDisplay.sprite = warriorMaleHuman;
                break;
            case "Warrior_Male_Elf":
                characterDisplay.sprite = warriorMaleElf;
                break;
            // ... adicione todos os casos necessários
        }
    }
    
    // Métodos públicos para os botões chamarem
    public void SelectClass(string className)
    {
        currentClass = className;
        UpdateCharacterDisplay();
    }
    
    public void SelectGender(string gender)
    {
        currentGender = gender;
        UpdateCharacterDisplay();
    }
    
    public void SelectRace(string race)
    {
        currentRace = race;
        UpdateCharacterDisplay();
    }
}