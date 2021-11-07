using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
	private XRRig rig;
	public XRNode inputSource; //set to left hand
	private Vector2 inputAxis;
	private CharacterController character;

	public float speed = 1f;
	public float additionalHeight = 0.2f;

	public bool applyGravity;
	public float gravity = -9.81f;
	public LayerMask groundLayer;
	private float fallingSpeed;

	void Start()
	{
		character = GetComponent<CharacterController>();
		rig = GetComponent<XRRig>();
	}
	void Update()
	{
		InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
		device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
	}

	private void FixedUpdate()
	{
		CapsuleFollowHeadset();
		Move();

		if(applyGravity)
			ApplyGravity();
	}

	private void Move()
    {
		Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
		Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);

		character.Move(direction * Time.fixedDeltaTime * speed);
	}

	private void ApplyGravity()
    {
		bool isGrounded = CheckIfGrounded();
		if (isGrounded)
			fallingSpeed = 0;
		else
			fallingSpeed += gravity * Time.fixedDeltaTime;

		character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
	}

	private bool CheckIfGrounded()
	{
		Vector3 rayStart = transform.TransformPoint(character.center);
		float rayLength = character.center.y + 0.01f;
		bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);

		return hasHit;
	}


	private void CapsuleFollowHeadset()
	{
		character.height = rig.cameraInRigSpaceHeight + additionalHeight;
		Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
		character.center = new Vector3(capsuleCenter.x, character.height / 2 + character.skinWidth, capsuleCenter.y);
	}
}