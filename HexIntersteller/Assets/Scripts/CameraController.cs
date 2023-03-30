using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HexInterstellar
{
	public class CameraController : CinemachineInputProvider
	{
		[SerializeField] private GameObject moveTarget;
		[SerializeField] private Rigidbody moveTargetRigidbody;
		[SerializeField] private Transform cinemachineVCam;
		[SerializeField] private InputActionReference activateOrbitControl, moveControl;
		[SerializeField, Range(1, 10)] private float speedMultiplier = 2;
		private InputAction activateOrbitAction, action, moveAction;
		private bool isActivated;
		private Vector2 moveInput;
		private Vector3 forward, right, fowardRelative, rightRelative, moveDirRelative, velocity;
		private float look;
		private void Start()
		{
			activateOrbitAction = activateOrbitControl.action;
			activateOrbitAction.Enable();
			moveAction = moveControl.action;
			moveAction.Enable();
		}
		private void Update()
		{
			moveInput = moveAction.ReadValue<Vector2>();
			forward = cinemachineVCam.forward;
			right = cinemachineVCam.right;
			fowardRelative = moveInput.y * forward;
			rightRelative = moveInput.x * right;
			moveDirRelative = fowardRelative + rightRelative;
			moveTarget.transform.Translate(moveDirRelative * (Time.deltaTime * speedMultiplier), Space.World);
		}
		// ReSharper disable Unity.PerformanceAnalysis
		public override float GetAxisValue(int axis)
		{
			if (!enabled) return 0;
			if (activateOrbitAction.ReadValue<float>() != 1) return 0;
			action = ResolveForPlayer(axis, axis == 2 ? ZAxis : XYAxis);
			if (action == null) return 0;
			// ReSharper disable once ConvertSwitchStatementToSwitchExpression
			switch (axis)
			{
				case 0: 
					look = action.ReadValue<Vector2>().x; 
					break;
				case 1: 
					look = action.ReadValue<Vector2>().y; 
					break;
				case 2: 
					look = action.ReadValue<float>(); 
					break;
				default: 
					look = 0; 
					break;
			}
			moveTarget.transform.LookAt(-cinemachineVCam.position);
			return look;
		}
	}
}


