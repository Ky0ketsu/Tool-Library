using UnityEditor;
using UnityEngine;

namespace Ky0ketsu.EditorOnly
{
    public class RandomSpawnerEditorWindow : EditorWindow
    {
        [SerializeField]
        private GameObject _prefabToSpawn = null;

        [SerializeField]
        private int _quantity = 100;

        [SerializeField]
        private Vector3 _spawnArea = Vector3.one * 100;

        [MenuItem("Tools/Random Spawner")]
        public static void OpenWindow()
        {
            RandomSpawnerEditorWindow window = GetWindow<RandomSpawnerEditorWindow>("Random Spawner");
            window.Show();
        }

        private void OnGUI()
        {
            _prefabToSpawn = EditorGUILayout.ObjectField("Prefab To Spawn", _prefabToSpawn, typeof(GameObject), false) as GameObject;
            _quantity = EditorGUILayout.IntField("Quantity", _quantity);
            _spawnArea = EditorGUILayout.Vector3Field("Spawn Area", _spawnArea);
            if(GUILayout.Button("Spawn ObjectRandomly"))
            {
                for(int i = 0; i < _quantity; i++)
                {
                    Vector3 randomPosition = new Vector3
                    (
                        Random.Range(0, _spawnArea.x),
                        Random.Range(0, _spawnArea.y),
                        Random.Range(0, _spawnArea.z)
                    );

                    Instantiate(_prefabToSpawn, randomPosition, Random.rotation);
                }
            }
        }
    }
}
