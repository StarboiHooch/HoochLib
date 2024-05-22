﻿using HoochLib.Generic.Checkpoints;
using UnityEngine;

namespace HoochLib.Generic
{
    public class StartAtCheckpoint : MonoBehaviour
    {
        [SerializeField]
        private Checkpoint checkpoint;

        // Use this for initialization
        void Start()
        {
            CheckpointSaver saver = this.gameObject.GetComponent<CheckpointSaver>();
            saver.SaveCheckpoint(checkpoint);
            saver.GoToCheckpoint();
        }
    }
}