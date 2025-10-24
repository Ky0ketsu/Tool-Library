using UnityEngine;
using UnityEditor;

namespace Ky0ketsu.EditorOnly
{
    [CustomEditor(typeof(Player))]
    public class PlayerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            //Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(40));

            GUI.enabled = Application.isPlaying;
            if(GUILayout.Button("Make player jump"))
            {
                Player player = target as Player;
                player.Jump();
            }

        }
    }
}
