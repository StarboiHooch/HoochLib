using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameJamHelpers.Generic
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
        [SerializeField]
        private float lifetime = 0f;
        [SerializeField]
        private bool makeObjectsChild = false;

        [SerializeField]
        private UnityEvent<GameObject> onInstantiate;

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
                GameObject instantiatedObject = Instantiate(prefab, this.gameObject.transform.position, Quaternion.identity, makeObjectsChild ? this.GetComponentInParent<Transform>() : null);
                onInstantiate?.Invoke(instantiatedObject);
                if (lifetime > 0f)
                {
                    StartCoroutine(DestroyAfterSeconds(instantiatedObject));
                }
            }
            else
            {
                Debug.LogError("No prefab selected for prefabEmitter");
            }
        }

        private IEnumerator DestroyAfterSeconds(GameObject instantiatedObject)
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(instantiatedObject);
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }
    }
}