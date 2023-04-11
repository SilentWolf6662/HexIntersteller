using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HexInterstellar
{
	public class CameraController : CinemachineInputProvider
	{
		[SerializeField] private CinemachineCameraOffset camOffset;
		[SerializeField] private float sensitivity = 10;
		[SerializeField] private InputActionReference activateOrbitInput, zoomInput;
		private InputAction action;
		private float look, cameraDistance;
		private Vector2 zoomInputValue;
		private bool iscomponentBaseNull;
		private void Start()
		{
			activateOrbitInput.action.Enable();
			zoomInput.action.Enable();
		}
		private void Update()
		{
			zoomInputValue = zoomInput.action.ReadValue<Vector2>();
			camOffset.m_Offset.z += zoomInputValue.y * (sensitivity * Time.deltaTime);
		}
		// ReSharper disable Unity.PerformanceAnalysis
		public override float GetAxisValue(int axis)
		{
			if (!enabled) return 0;
			if (activateOrbitInput.action.ReadValue<float>() != 1) return 0;
			action = ResolveForPlayer(axis, axis == 2 ? ZAxis : XYAxis);
			if (action == null) return 0;
			return axis switch { 0 => action.ReadValue<Vector2>().x, 1 => action.ReadValue<Vector2>().y, 2 => action.ReadValue<float>(), _ => 0 };
		}
	}
}


