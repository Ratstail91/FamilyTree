using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {
	//camera
	[SerializeField]
	Camera cam = null;

	//line drawing utility
	[SerializeField]
	Texture lineTexture = null;

	[SerializeField]
	Node[] nodeArray = null;

	void OnGUI() {
		for (int i = 1; i < nodeArray.Length; i++) {
			DrawLine(WorldToGUIPoint(nodeArray[i-1].transform.position), WorldToGUIPoint(nodeArray[i].transform.position), 2);
		}
	}

	void DrawLine(Vector2 first, Vector2 second, float width) {
		//parse the line data
		Vector2 midPoint = new Vector2((first.x + second.x) / 2, (first.y + second.y) / 2);
		float halfLength = (second - first).magnitude / 2;

		//O = Asin (o / (h / sin(H)) )
//		float angle = 90 - Mathf.Asin((second.x - first.x) / ( ((second-first).magnitude) / Mathf.Sin(90*Mathf.Deg2Rad)) ) * Mathf.Rad2Deg;
		float angle = Mathf.Atan2(second.y-first.y, second.x-first.x) * Mathf.Rad2Deg;

		//draw the line
		Rect rect = new Rect(midPoint.x - halfLength, midPoint.y - width / 2, halfLength * 2, width);

		GUI.BeginGroup(new Rect(0, 0, Screen.width, Screen.height));

		GUIUtility.RotateAroundPivot(angle, midPoint);
		GUI.DrawTexture(rect, lineTexture);
		GUIUtility.RotateAroundPivot(-angle, midPoint);

		GUI.EndGroup();
	}

	public Vector3 WorldToGUIPoint(Vector3 position) {
		var guiPosition = cam.WorldToScreenPoint(position);
		guiPosition.y = Screen.height - guiPosition.y;
		return guiPosition;
	}
}