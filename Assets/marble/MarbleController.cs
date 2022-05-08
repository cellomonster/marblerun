using UnityEngine;

public class MarbleController : MonoBehaviour
{
	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private new Camera camera;
	[SerializeField] private float torqueMagnitude = 5;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void LateUpdate()
	{
		var forward = camera.transform.forward;
		forward.y = 0;
		forward.Normalize();

		var right = camera.transform.right;
		forward.y = 0;
		forward.Normalize();

		var torque = Vector3.zero;
		torque += Input.GetAxis("Mouse X") * -forward;
		torque += Input.GetAxis("Mouse Y") * right;
		Vector3.ClampMagnitude(torque, 1);
		torque *= torqueMagnitude;

		rigidbody.AddTorque(torque, ForceMode.VelocityChange);
	}
}