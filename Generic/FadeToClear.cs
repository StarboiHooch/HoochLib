using UnityEngine;

namespace Assets.Modules.GameJamHelpers.Generic
{
    public class FadeToClear : MonoBehaviour
    {
        [SerializeField]
        private bool fadeOnStart = true;
        [SerializeField]
        private float fadeTime = 1f;
        private float timer = 0f;
        private bool fading = false;
        private Color startColor;


        // Use this for initialization
        void Start()
        {
            if (fadeOnStart)
            {
                StartFade();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (fading)
            {
                if (timer <= fadeTime)
                {
                    GetComponent<SpriteRenderer>().color = new Color(startColor.r, startColor.g, startColor.b, Mathf.Lerp(startColor.a, 0, timer / fadeTime));
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(startColor.r, startColor.g, startColor.b, 0f);
                    fading = false;
                }
                timer += Time.deltaTime;
            }
        }

        public void StartFade()
        {
            if (!fading)
            {
                timer = 0f;
                startColor = GetComponent<SpriteRenderer>().color;
                fading = true;
            }
        }
    }
}