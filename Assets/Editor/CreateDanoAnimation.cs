using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.IO;
using System.Linq;

public class CreateDanoAnimation
{
    private const string ROOT_PATH = "Assets/Resources/Caracters";

    [MenuItem("Tools/Criar Animation Dano")]
    public static void CreateDano()
    {
        string[] animationFolders = Directory.GetDirectories(
            ROOT_PATH,
            "animation",
            SearchOption.AllDirectories
        );

        int createdCount = 0;

        foreach (string folder in animationFolders)
        {
            // Procura AnimatorController
            string controllerPath = Directory.GetFiles(folder, "*.controller").FirstOrDefault();
            if (controllerPath == null)
            {
                Debug.LogWarning("⚠ Nenhum AnimatorController em: " + folder);
                continue;
            }

            // Verifica se já existe dano.anim
            string danoAnimPath = Path.Combine(folder, "dano.anim").Replace("\\", "/");
            if (File.Exists(danoAnimPath))
            {
                continue;
            }

            // Cria AnimationClip
            AnimationClip danoClip = new AnimationClip
            {
                name = "dano"
            };

            AssetDatabase.CreateAsset(danoClip, danoAnimPath);

            // Carrega AnimatorController
            AnimatorController controller =
                AssetDatabase.LoadAssetAtPath<AnimatorController>(controllerPath);

            // Adiciona State no primeiro layer
            AnimatorStateMachine sm = controller.layers[0].stateMachine;
            AnimatorState state = sm.AddState("dano");
            state.motion = danoClip;

            createdCount++;
            Debug.Log("✅ Criado dano.anim em: " + folder);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log($"Processo finalizado. Animations criadas: {createdCount}");
    }
}
