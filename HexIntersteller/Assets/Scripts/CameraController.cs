using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HexInterstellar
{
	public class CameraController : CinemachineInputProvider
	{
		[SerializeField] private GameObject moveTarget;
		[SerializeField] private GameObject cinemachineVCam;
		[SerializeField] private InputActionReference activateOrbitControl, moveControl;
		[SerializeField, Range(1, 10)] private float speedMultiplier = 2;
		private InputAction activateOrbitAction, action, moveAction;
		private bool isActivated;
		private Vector2 moveDir;
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
			moveDir = moveAction.ReadValue<Vector2>();
			if (moveDir.x > 0)
				moveTarget.transform.position += Vector3.right * (Time.deltaTime * speedMultiplier);
			if (moveDir.x < 0)
				moveTarget.transform.position += Vector3.left * (Time.deltaTime * speedMultiplier);
			if (moveDir.y > 0)
				moveTarget.transform.position += Vector3.forward * (Time.deltaTime * speedMultiplier);
			if (moveDir.y < 0)
				moveTarget.transform.position += Vector3.back * (Time.deltaTime * speedMultiplier);
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
				case 0: look = action.ReadValue<Vector2>().x;
					break;
				case 1: look = action.ReadValue<Vector2>().y;
					break;
				case 2: look = action.ReadValue<float>();
					break;
				default: look = 0;
					break;
			}
			moveTarget.transform.LookAt(-cinemachineVCam.transform.position);
			return look;
		}
	}
}


