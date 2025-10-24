using System.Transactions;
using UnityEngine;

namespace Ky0ketsu
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private bool _canAttack;

        [SerializeField, EnableIf(nameof(_canAttack))]
        private float _attackRange = 4.0f;

        [Header("Debug")]

        [SerializeField]
        private bool _showDebugGUI = false;

        private Rigidbody _rigidBody = null;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        public void Jump()
        {
            Debug.Log("Saute");
        }

        private void OnGUI()
        {
            if (!_rigidBody)
                return;

            float speed = _rigidBody.linearVelocity.magnitude;
            using (new GUILayout.VerticalScope(GUI.skin.box))
            {
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Player speed");
                    GUILayout.Label(speed.ToString("0.000"));
                }
            }
        }
    }
}
