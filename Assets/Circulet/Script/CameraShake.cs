using UnityEngine;

[AddComponentMenu("Camera/Camera Shake")]
public class CameraShake : MonoBehaviour
{
	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;

	bool cameraShakeFlag = false;

	UIController _uiController;

	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		_uiController = FindObjectOfType<UIController>();
		originalPos = camTransform.localPosition;
	}

	void Update()
	{
		if (cameraShakeFlag)
		{
			if (shakeDuration > 0)
			{
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

				shakeDuration -= Time.deltaTime * decreaseFactor;
			}
			else
			{
				_uiController.LoadGameover();
				shakeDuration = 0f;
				cameraShakeFlag = false;
				camTransform.localPosition = originalPos;
			}
		}
	}

	public void ShakeCamera(float _shakeDuration)
	{
		cameraShakeFlag = true;
		originalPos = camTransform.localPosition;
		shakeDuration = _shakeDuration;
	}
}
