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
        var root = new VisualElement();
        Button btnBowser = new Button(SpawnBowser);
        root.Add(btnBowser);
        Button btnChamp = new Button(SpawnChamp);
        root.Add(btnChamp);
        return root;
    }
    private void SpawnBowser()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameManager gameManager = null;
        foreach (GameObject obj in scene.GetRootGameObjects())
        {
            if (obj.CompareTag("GameManager"))
            {
                gameManager = obj.GetComponent<GameManager>();
                break;
            }
        }
    }
    void SpawnChamp()
    {
        
    }
}
