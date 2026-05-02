using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float floatAmplitude = 0.3f;
    public float floatSpeed = 1f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        transform.position = new Vector3(
            startPosition.x,
            startPosition.y + offsetY,
            startPosition.z
        );
    }
}
