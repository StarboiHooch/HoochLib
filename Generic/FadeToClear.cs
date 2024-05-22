using System.Collections;
using UnityEngine;

namespace HoochLib.Generic
{

    public class FadeToClear : MonoBehaviour
    {
        [SerializeField]
        private bool fadeOnStart = true;

        [SerializeField]
        private float time = 5f;
        private float timer = 0f;

        [SerializeField]
        private bool destroyOnFaded = true;

        private SpriteRenderer sr;
        private Color startColor;
        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            startColor = sr.color;
            if (fadeOnStart) { StartCoroutine(Fade()); }

        }

        private IEnumerator Fade()
        {
            while (timer < time)
            {
                sr.color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0, timer / time));
                timer += Time.deltaTime;
                yield return null;
            }
            sr.color = new Color(startColor.r, startColor.g, startColor.b, 0);
            if (destroyOnFaded)
            {
                Destroy(this.gameObject);
            }
        }

    }
}