using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {
	[SerializeField]
	GameObject linePrefab = null;

	[SerializeField]
	Node[] nodeArray = null;

	void Start() {
		//get the points as a list
		List<Vector3> list = new List<Vector3>();

		for (int i = 0; i < nodeArray.Length; i++) {
			list.Add(nodeArray[i].transform.position);
		}

		GameObject go = Instantiate(linePrefab, transform);
		Line line = go.GetComponent<Line>();

		line.points = list.ToArray();
	}
}