using UnityEngine;

namespace Assets.Modules.GameJamHelpers.Generic
{
    public class PrefabEmitter : MonoBehaviour
    {
        [SerializeField]
        private GameObject prefab;
        [SerializeField]
        private bool active = true;
        [SerializeField]
        [Tooltip("Leave at 0 to emit the prefab every frame")]
        private float interval = 0f;
        private float timer = 0f;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (active)
            {
                timer += Time.deltaTime;
                if (timer >= interval)
                {
                    timer = 0f;
                    Emit();
                }
            }
        }

        public void Emit()
        {
            if (prefab != null)
            {
                Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No prefab selected for prefabEmitter");
            }
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }
    }
}