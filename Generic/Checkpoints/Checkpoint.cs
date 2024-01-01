using GameJamHelpers.Generic.Checkpoints;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;
    public Vector3 SpawnPosition => spawnPosition.position;

    [SerializeField]
    private UnityEvent onCheckpointUsed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckpointSaver checkpointSaver = collision.GetComponent<CheckpointSaver>();
        if (checkpointSaver == null)
        {
            checkpointSaver = collision.GetComponentInParent<CheckpointSaver>();
        }
        if (checkpointSaver != null)
        {
            checkpointSaver.SaveCheckpoint(this);
        }
    }

    public void ActivateCheckpoint()
    {
        onCheckpointUsed?.Invoke();
    }

}
