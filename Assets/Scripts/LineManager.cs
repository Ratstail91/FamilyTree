using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {
	//line drawing utility
	[SerializeField]
	Texture lineTexture = null;

	void OnGUI() {
		DrawLine(new Vector2(50, 50), new Vector2(100, 100), 5);

		DrawLine(new Vector2(100, 100), new Vector2(500, 500), 5);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;

		Vector3 offset = new Vector3(-10, 5, 0);

		for (int i = 0; i < 10; i++) {
			Gizmos.DrawLine(new Vector3(i, 0, 0) + offset, new Vector3(i, -10, 0) + offset);
		}

		for (int j = 0; j < 10; j++) {
			Gizmos.DrawLine(new Vector3(0, -j, 0) + offset, new Vector3(10, -j, 0) + offset);
		}
	}

	void DrawLine(Vector2 first, Vector2 second, float width) {
		//parse the line data
		Vector2 midPoint = new Vector2((first.x + second.x) / 2, (first.y + second.y) / 2);
		float halfLength = (second - first).magnitude / 2;

		float angle = ((second.x - first.x) / (second - first).magnitude) * (180 / Mathf.PI);

		//draw the line
		Rect rect = new Rect(midPoint.x - halfLength, midPoint.y - 5, halfLength * 2, width);

		Debug.Log(midPoint);
		Debug.Log(halfLength);
		Debug.Log(angle);
		Debug.Log(rect);

		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		GUIUtility.RotateAroundPivot(angle, midPoint);
		GUI.DrawTexture(rect, lineTexture);
		GUIUtility.RotateAroundPivot(-angle, midPoint);

		GUI.EndGroup();
	}
}