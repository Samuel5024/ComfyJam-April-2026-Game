using UnityEngine;

public class IndicatorMovement : MonoBehaviour
{
    Vector3 DesiredLocation;
    Quaternion DesiredRotation;
    float smoothing = 0.01f;
    [SerializeField] float timeofset;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, DesiredLocation, smoothing * Time.deltaTime * timeofset);
        transform.rotation = Quaternion.Lerp(transform.rotation, DesiredRotation, smoothing * Time.deltaTime * timeofset);
    }

    public void SetDesiredLocation(Vector3 location)
    {
        DesiredLocation = location;
    }

    public void SetDesiredRotation(Quaternion rotation)
    {
        DesiredRotation = rotation;
    }

    public void SetSmoothing(float smoothing)
    {
        this.smoothing = smoothing;
    }
}
