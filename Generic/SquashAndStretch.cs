using System.Collections;
using UnityEngine;

public class SquashAndStretch : MonoBehaviour
{
    [SerializeField]
    private float defaultSquashHeight = 0.6f;
    [SerializeField]
    private float defaultSquashTime = 0.6f;

    private float initialHeight;
    private float initialWidth;
    private bool coroutineActive = false;
    private float squashHeight;
    private float squashWidth;
    private float squashTime;
    private float timer = 0f;
    private Coroutine currentCoroutine;




    // Start is called before the first frame update
    void Start()
    {
        initialHeight = transform.localScale.y;
        initialWidth = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Squash()
    {
        if (!coroutineActive)
        {
            StartCoroutine(SquashAndStretchCoroutine());
        }
    }

    IEnumerator SquashAndStretchCoroutine()
    {
        coroutineActive = true;
        SetSquashAndStretchParameters(defaultSquashHeight, defaultSquashTime);
        while (timer < squashTime)
        {
            transform.localScale = new Vector3(SquashLerp(initialWidth, squashWidth), SquashLerp(initialHeight, squashHeight), transform.localScale.z);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector3(initialWidth, initialHeight, transform.localScale.z);
        coroutineActive = false;

    }

    public void SetSquashAndStretchParameters(float amount, float time)
    {
        timer = 0f;
        squashHeight = amount;
        squashWidth = CalculateSquashWidth(amount);
        squashTime = time;
    }


    private float CalculateSquashWidth(float height)
    {
        float area = initialHeight * initialWidth;
        return area / height;
    }

    private float SquashLerp(float initialValue, float targetValue)
    {
        if (timer < squashTime / 2)
        {
            float lerpProgress = timer / (squashTime / 2);
            return Mathf.Lerp(initialValue, targetValue, lerpProgress);
        }
        else
        {
            float lerpProgress = (timer - (squashTime / 2)) / (squashTime / 2);
            return Mathf.Lerp(targetValue, initialValue, lerpProgress);
        }
    }
}
