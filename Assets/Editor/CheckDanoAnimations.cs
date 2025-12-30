using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

public class CheckDanoAnimations
{
    private const string ROOT_PATH = "Assets/Resources/Caracters";

    [MenuItem("Tools/Verificar Animations sem Dano")]
    public static void CheckAnimations()
    {
        if (!Directory.Exists(ROOT_PATH))
        {
            Debug.LogError("Caminho não encontrado: " + ROOT_PATH);
            return;
        }

        // Procura todas as pastas chamadas "animation"
        string[] animationFolders = Directory.GetDirectories(
            ROOT_PATH,
            "animation",
            SearchOption.AllDirectories
        );

        int missingCount = 0;

        foreach (string folder in animationFolders)
        {
            // Procura qualquer arquivo que comece com "dano"
            bool hasDano = Directory.GetFiles(folder)
                .Any(f => Path.GetFileNameWithoutExtension(f).ToLower() == "dano");

            if (!hasDano)
            {
                missingCount++;
                Debug.Log("❌ Falta arquivo 'dano' em: " + folder);
            }
        }

        Debug.Log($"Verificação finalizada. Pastas sem 'dano': {missingCount}");
    }
}
