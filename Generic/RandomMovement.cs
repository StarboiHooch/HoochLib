using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField]
    private float minDistance = 3f;
    [SerializeField]
    private float maxDistance = 5f;
    [SerializeField]
    private float minAngle = -45f;
    [SerializeField]
    private float maxAngle = 45f;
    [SerializeField]
    private float minTime = 0.5f;
    [SerializeField]
    private float maxTime = 1f;
    [SerializeField]
    private AnimationCurve animationCurve;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float startAngle;
    private float targetAngle;
    private float time;

    private float timer;

    private void Start()
    {
        SetRandomParameters();
    }

    private void SetRandomParameters()
    {
        timer = 0;
        startPosition = transform.position;
        int xDir = (Random.Range(0, 2) * 2) - 1;
        int yDir = (Random.Range(0, 2) * 2) - 1;
        targetPosition = transform.position + new Vector3((float)xDir * Random.Range(minDistance, maxDistance), (float)yDir * Random.Range(minDistance, maxDistance), 0f);
        time = Random.Range(minTime, maxTime);
        startAngle = transform.rotation.eulerAngles.z;
        targetAngle = Random.Range(minAngle, maxAngle);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, animationCurve.Evaluate(timer / time));
        Quaternion currentRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Mathf.Lerp(startAngle, targetAngle, timer / time));
        gameObject.transform.SetPositionAndRotation(currentPos, currentRot);
        timer += Time.deltaTime;
        if (timer > time)
        {
            SetRandomParameters();
        }
    }
}
