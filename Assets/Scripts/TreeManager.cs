using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeManager : MonoBehaviour {

	public List<GameObject> UnusedBranches;
	public int BranchCount = 8;

	// Use this for initialization
	void Start () {


	}

	void CreateBranch(bool rightSide) {

		GameObject newBranch = null;
		while (newBranch == null) {
			foreach (var branch in UnusedBranches) {
				if (!branch.GetComponent<BranchScript>().IsInstantiated) {
					newBranch = branch;
					break;
				}
			}
		}

		if (rightSide) {
			newBranch.transform.Translate(5, newBranch.transform.position.y + 12, 0);
		}
		else {
			newBranch.transform.Translate(-5, newBranch.transform.position.y + 12, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
