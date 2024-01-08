using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScalerModule))]
public class ScalerModuleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ScalerModule scalerModule = (ScalerModule)target;

        if (GUILayout.Button("Start Scaling"))
        {
            scalerModule.ActivateModule();
        }

        if (GUILayout.Button("Return to Default"))
        {
            scalerModule.ReturnToDefaultState();
        }
    }
}
