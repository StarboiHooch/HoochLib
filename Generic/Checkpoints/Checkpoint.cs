using Assets.Modules.GameJamHelpers.Generic.Checkpoints;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPosition;
    public Vector3 SpawnPosition => spawnPosition.position;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckpointSaver checkpointSaver = collision.GetComponent<CheckpointSaver>();
        if (checkpointSaver != null)
        {
            checkpointSaver.SaveCheckpoint(this);
        }
    }

}
