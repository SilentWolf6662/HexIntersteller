using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : CinemachineInputProvider
{
	[SerializeField] private GameObject moveTarget;
	[SerializeField] private InputActionReference activateOrbitControl, moveControl;
	[SerializeField, Range(1, 10)] private float speedMultiplier = 2;
	private InputAction activateOrbitAction, action, moveAction;
	private bool isActivated;
	private Vector2 moveDir;
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
		if (moveDir.x != 0 || moveDir.y != 0) moveTarget.transform.position += new Vector3(moveDir.x * Time.deltaTime * speedMultiplier, 0, moveDir.y * Time.deltaTime * speedMultiplier);
	}
	public override float GetAxisValue(int axis)
	{
		if (enabled)
		{
			if (activateOrbitAction.ReadValue<float>() == 1)
			{
				action = ResolveForPlayer(axis, axis == 2 ? ZAxis : XYAxis);
				if (action != null)
				{
					switch (axis)
					{
						case 0: return action.ReadValue<Vector2>().x;
						case 1: return action.ReadValue<Vector2>().y;
						case 2: return action.ReadValue<float>();
					}
				}
			}
		}
		return 0;
	}
}


