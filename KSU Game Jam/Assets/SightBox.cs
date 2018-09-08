using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SightBox : MonoBehaviour {
	
	Vector3 boxSize;
	LayerMask mask;
	public enum colliderState {inactive, active, colliding }
	public Color inactiveColor;
	public Color collidingColor;
	public Color activeColor;
	private colliderState state;


	void update (){
		Collider[] colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation, mask);

		if (colliders.Length > 0) {
			Debug.Log("We hit something");
		}
	
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
}
