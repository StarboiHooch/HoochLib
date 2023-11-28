using System;
using UnityEngine;

namespace GameJamHelpers.Generic
{
    public class Counter : MonoBehaviour
    {
        [SerializeField]
        private int count = 0;
        public int Count => count;
        [SerializeField]
        private int startingCount = 0;

        public event EventHandler CountChanged;

        // Use this for initialization
        void Start()
        {
            count = startingCount;
        }
        public void Reset()
        {
            SetCount(count);
        }

        public void Increment(int amount = 1)
        {
            SetCount(count + amount);
        }

        public void Decrement(int amount = 1)
        {
            SetCount(count - amount);
        }

        public void SetCount(int count)
        {
            this.count = count;
            CountChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}