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

	//internals

	//
}