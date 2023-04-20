using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace HexInterstellar.Movement
{
	public class CameraController : CinemachineInputProvider
	{
		[SerializeField] private CinemachineCameraOffset camOffset;
		[SerializeField] private float zoomSensitivity = 1;
		[SerializeField] private float sensitivity = 1;
		[SerializeField] private InputActionReference activateOrbitInput, zoomInput;
		private InputAction action;
		private float cameraDistance;
		private Vector2 zoomInputValue;
		private void Start()
		{
			// Activates the scroll wheel action input and right mouse button action input
			activateOrbitInput.action.Enable();
			zoomInput.action.Enable();
		}
		private void Update()
		{
			// Reads mouse wheel values in a Vector2
			zoomInputValue = zoomInput.action.ReadValue<Vector2>();

			// Takes z offset and adding mouse wheel y multiplied with sensitivity
			// that multiplies with Time.deltaTime to make the same feeling of smooth zoom
			camOffset.m_Offset.z += zoomInputValue.y * (zoomSensitivity * Time.deltaTime);
		}
		// ReSharper disable Unity.PerformanceAnalysis
		public override float GetAxisValue(int axis)
		{             
			// Checks if input is enabled                               
			if (!enabled) return 0;

			// Checks if mouse right btn is held down
			if (activateOrbitInput.action.ReadValue<float>() != 1) return 0;

			// Resovles the movement based on axises
			action = ResolveForPlayer(axis, axis == 2 ? ZAxis : XYAxis);
			if (action == null) return 0;
			return axis switch { 0 => action.ReadValue<Vector2>().x * sensitivity * Time.deltaTime, 1 => action.ReadValue<Vector2>().y * sensitivity * Time.deltaTime, 2 => action.ReadValue<float>() * sensitivity * Time.deltaTime, _ => 0 * sensitivity * Time.deltaTime };
		}
	}
}


