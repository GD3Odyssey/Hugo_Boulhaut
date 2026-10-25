using UnityEngine;
using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[Overlay(typeof(SceneView), "Scriptable Tools")]
public class ScriptableTools : Overlay
{
    public override VisualElement CreatePanelContent()
    {
        VisualElement panel = new VisualElement();
        Button btnCoin = new Button(SpawnCoin) { text = "Spawn Coin" };
        btnCoin.style.height = 48;
        panel.Add(btnCoin);

        Button btnEnemy = new Button(SpawnEnemy) { text = "Spawn Enemy" };
        btnEnemy.style.height = 48;
        panel.Add(btnEnemy);

        Button btnPistol = new Button(SpawnPistol) { text = "Spawn Pistol" };
        btnPistol.style.height = 48;
        panel.Add(btnPistol);

        return panel;
    }
    private void Spawn(string prefabName)
    {
        GameObject prefab = Resources.Load<GameObject>(prefabName);

        GameObject obj = (GameObject)PrefabUtility.InstantiatePrefab(
            prefab, SceneManager.GetActiveScene());

        obj.transform.position = SceneView.lastActiveSceneView.pivot;

        Undo.RegisterCreatedObjectUndo(obj, "Spawn " + prefabName);
    }
       private void SpawnCoin()
    {
        Spawn("Coin");
    }

    private void SpawnEnemy()
    {
        Spawn("Enemy");
    }

    private void SpawnPistol()
    {
        Spawn("PickUpPistol Variant");
    }


}
