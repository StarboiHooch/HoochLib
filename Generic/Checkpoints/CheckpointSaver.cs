using UnityEngine;
using UnityEngine.Events;

namespace GameJamHelpers.Generic.Checkpoints
{
    public class CheckpointSaver : MonoBehaviour
    {
        [SerializeField]
        private bool active = true;
        public bool Active => active;


        [SerializeField]
        private Checkpoint lastCheckpoint = null;
        private Vector3 startPosition;

        [SerializeField]
        private UnityEvent onCheckpointSaved;

        [SerializeField]
        private GameObject item;

        private void Start()
        {
            startPosition = transform.position;
        }

        public void SaveCheckpoint(Checkpoint checkpoint)
        {
            lastCheckpoint = checkpoint;
            onCheckpointSaved?.Invoke();
        }

        public void ClearCheckpoint() { lastCheckpoint = null; }

        /// <summary>
        /// Moves the gameobject to the last checkpoint if one is saved
        /// </summary>
        /// <returns>Whether there was a checkpoint saved</returns>
        public void GoToCheckpoint()
        {
            if (lastCheckpoint != null)
            {
                this.gameObject.transform.position = lastCheckpoint.SpawnPosition;
            }
            else
            {
                this.gameObject.transform.position = startPosition;
            }
        }

        public void SendToCheckpoint()
        {
            if (lastCheckpoint != null)
            {
                lastCheckpoint.ActivateCheckpoint();
                item.transform.position = lastCheckpoint.SpawnPosition;
            }
            else
            {
                item.transform.position = startPosition;
            }
        }

    }
}