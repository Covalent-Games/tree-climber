using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeManager : MonoBehaviour {

	public List<GameObject> UnusedBranches;
	public List<GameObject> UsedBranches;
	public int BranchCount = 8;

	float BranchTimer = 0;
	public float BranchInterval;


	// Use this for initialization
	void Start () {

	
	}


	void IncrementBranchTimer() {
		BranchTimer += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {

		IncrementBranchTimer();

		if (BranchTimer > BranchInterval) {
			BranchTimer = 0;
			if (UnusedBranches.Count > 1) {
				GameObject branch1 = UnusedBranches[0];
				GameObject branch2 = UnusedBranches[1];
				UsedBranches.Add(branch1);
				UsedBranches.Add(branch2);
				UnusedBranches.Remove(branch1);
				UnusedBranches.Remove(branch2);

				int rand = Random.Range(0, 3);
				branch1.transform.Rotate(0, rand * 90, 0);
				int rand2 = Random.Range(0, 3);
				if (rand2 == rand) {
					rand2 = (rand2 + Random.Range(1,3)) % 4;
				}
				branch2.transform.Rotate(0, rand2 * 90, 0);
			}
		}
		foreach (var branch in UsedBranches) {
			branch.transform.position = new Vector3(0, branch.transform.position.y - (Time.deltaTime * 2), 0);
			//branch.transform.Translate(branch.transform.position.x, branch.transform.position.y - (Time.deltaTime), branch.transform.position.z);
			if (branch.transform.position.y < -0.6) {
				branch.transform.position = new Vector3(0, 0.75f, 0);
				UnusedBranches.Add(branch);
			}
		}
		foreach (var branch in UnusedBranches) {
			if (UsedBranches.Contains(branch))
				UsedBranches.Remove(branch);
		}
	}
}
