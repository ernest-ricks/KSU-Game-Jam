using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SightBox : MonoBehaviour {
	
	public Vector3 boxSize;
	LayerMask mask;
	public enum colliderState {inactive, active, colliding }
	public Color inactiveColor;
	public Color collidingColor;
	public Color activeColor;
	private colliderState state;
	private ISightboxResponder _responder = null;

	void Update()
	{
		if (state == colliderState.inactive)
		{
			return;
		}
		Collider[] colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation, mask);

		if (colliders.Length > 0)
		{
			state = colliderState.colliding;
		}
		else
		{
			state = colliderState.active;
		}
		for (int i = 0; i < colliders.Length; i++)
		{
			Collider aCollider = colliders[i];
			// TODO ask tayler about null operand replacement.
			_responder.collisionedWith(aCollider);
		}
		state = colliders.Length > 0 ? colliderState.colliding :
			colliderState.active;

	}


	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
		Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, boxSize.z * 2));
	}
	private void CheckGizmoColor()
	{
		switch (state)
		{
			case colliderState.inactive:
				Gizmos.color = inactiveColor;
				break;
			case colliderState.active:
				Gizmos.color = activeColor;
				break;
			case colliderState.colliding:
				Gizmos.color = collidingColor;
				break;
		}


	}
	public void startCheckingCollision()
	{
		state = colliderState.active;
	}
	public void stopCheckingCollision()
	{
		state = colliderState.inactive;
	}
	public interface ISightboxResponder
	{
		void collisionedWith(Collider collider); 
	}
	public void useResponder(ISightboxResponder responder)
	{
		_responder = responder;
	}
}
