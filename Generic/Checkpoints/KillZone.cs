using UnityEngine;

namespace GameJamHelpers.Generic.Checkpoints
{
    public class KillZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            CheckpointSaver checkpointSaver = collision.GetComponent<CheckpointSaver>();
            if (checkpointSaver != null)
            {
                checkpointSaver.GoToCheckpoint();
            }
        }
    }
}