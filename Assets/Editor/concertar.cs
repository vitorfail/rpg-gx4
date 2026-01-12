using UnityEditor;
using UnityEngine;

public class FixCharacterBodies
{
    [MenuItem("Tools/Fix Character Bodies Rigidbody2D")]
    static void FixBodies()
    {
        // Procura todos os prefabs dentro de Resources/Caracters
        string[] guids = AssetDatabase.FindAssets(
            "t:Prefab",
            new[] { "Assets/Resources/Caracters" }
        );

        int fixedCount = 0;

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null) continue;

            // Abre o prefab para edição
            GameObject instance = PrefabUtility.LoadPrefabContents(path);

            Rigidbody rb = instance.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
                fixedCount++;
            }
            else
            {
                Debug.LogWarning($"Prefab {prefab.name} não tem Rigidbody2D no Corpo");
            }


            // Salva e fecha o prefab
            PrefabUtility.SaveAsPrefabAsset(instance, path);
            PrefabUtility.UnloadPrefabContents(instance);
        }

        Debug.Log($"Processo finalizado! {fixedCount} corpos corrigidos.");
    }
}
