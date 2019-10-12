using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
	enum Type {
		MARRIAGE, CHILDREN
	};

	//for marriage lines
	public Node mother;
	public Node father;

	//for children line
	public Line parentLine;
	public Node[] children; //array for twins, etc.

	//general
	public Vector3[] points; //TODO: private

	//internals
	LineRenderer lineRenderer;

	void Awake() {
		lineRenderer = GetComponent<LineRenderer>();
	}

	void Update() {
		lineRenderer.SetPositions(points);
		lineRenderer.positionCount = points.Length;
	}
}