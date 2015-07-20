using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float Position;
	bool touching = false;
	Vector2 startTouchPosition = new Vector2();
	bool swiped = false;

	// Use this for initialization
	void Start () {
		Position = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.isEditor) {
			if (Input.GetMouseButton(0)) {

				if (!swiped) {
					if (!touching) {
						touching = true;
						startTouchPosition = new Vector2(Input.mousePosition.x, 0);
					} else if (Input.mousePosition.x - startTouchPosition.x > 10) {
						Position += 90f;
						Position = Position % 360f;
						swiped = true;
					} else if (Input.mousePosition.x - startTouchPosition.x < -10) {
						Position -= 90f;
						if (Position < 0)
							Position = 360 - (Mathf.Abs(Position) % 360);
						swiped = true;
					}
				}

			} else if (touching) {
				touching = false;
				swiped = false;
			}
		} else {


			if (Input.touchCount > 0) {
				if (!swiped) {
					var touch = Input.touches[0];

					if (!touching) {
						touching = true;
						startTouchPosition = touch.position;
					} else if (touch.position.x - startTouchPosition.x > 10) {
						Position += 90f;
						Position = Position % 360f;
						swiped = true;
					} else if (touch.position.x - startTouchPosition.x < -10) {
						Position -= 90f;
						if (Position < 0)
							Position = 360 - (Mathf.Abs(Position) % 360);
						swiped = true;
					}
				}

			} else if (touching) {
				touching = false;
				swiped = false;
			}
		}

		//if (Input.GetKeyDown("left")) {
		//	Position += 90f;
		//	Position = Position % 360f;
		//} else if (Input.GetKeyDown("right")) {
		//	Position -= 90f;
		//	if (Position < 0)
		//		Position = 360 - (Mathf.Abs(Position) % 360);
		//	Debug.Log("Spin from " + transform.parent.rotation.eulerAngles.y + " to " + Position);
		//}
		Spin();
		
		////Rotation controls B
		//if (Input.GetKey("left")) {
		//	transform.parent.Rotate(Vector3.up, 70 * Time.deltaTime);
		//} else if (Input.GetKey("right")) {
		//	transform.parent.Rotate(Vector3.up, -70 * Time.deltaTime);
		//}
		//if (Input.GetKey("up")) {
		//	transform.parent.Translate(0, 10 * Time.deltaTime, 0);
		//} else if (Input.GetKey("down")) {
		//	transform.parent.Translate(0, -10 * Time.deltaTime, 0);
		//}
		
	}

	void Spin() {
		if (transform.parent.rotation.eulerAngles != new Vector3(0, Position, 0)) {
			//Debug.Break();
			float spinTo = Position;
			if (Position == 0 && transform.parent.rotation.eulerAngles.y > 180) {
				spinTo = 360;
			} else if (Position == 270 && transform.parent.rotation.eulerAngles.y < 90) {
				Debug.Log("BLARGH!");
				transform.parent.rotation = Quaternion.Euler(new Vector3(0, 360 - 300 * Time.deltaTime, 0));
				return;
			}
			transform.parent.rotation = Quaternion.Euler(Vector3.MoveTowards(transform.parent.rotation.eulerAngles, new Vector3(0, spinTo, 0), 500 * Time.deltaTime));
		}
	}
}
