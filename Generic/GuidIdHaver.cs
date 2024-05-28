using System;
using UnityEngine;

namespace HoochLib.Generic
{
    public class GuidIdHaver : MonoBehaviour
    {
        [SerializeField]
        private string id;
        public string ID => id;

        [SerializeField]
        private bool idSet = false;

        private void OnValidate()
        {
            if (!idSet && this.gameObject.scene.buildIndex != -1)
            {
                id = Guid.NewGuid().ToString();
                idSet = true;
            }
        }
    }
}
