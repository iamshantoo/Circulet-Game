using UnityEngine;

public class ColorLerpGradiant : MonoBehaviour
{
    public Gradient myGradient;
    public float strobeDuration = 2f;

    Camera _cam;

    public void OnEnable()
    {
        _cam = Camera.main;
    }

    public void Update()
    {
        float t = Mathf.PingPong(Time.time / strobeDuration, 1f);
        _cam.backgroundColor = myGradient.Evaluate(t);
    }
}
