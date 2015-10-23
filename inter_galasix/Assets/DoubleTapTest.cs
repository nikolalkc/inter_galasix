using UnityEngine;
using System.Collections;

public class DoubleTapTest : MonoBehaviour {
	public float _doubleTapTimeD;

	// Update is called once per frame
	void Update() {
		bool doubleTapD = false;

		#region doubleTapD

		if (Input.GetKeyDown(KeyCode.D)) {
			if (Time.time < _doubleTapTimeD + .3f) {
				doubleTapD = true;
			}
			_doubleTapTimeD = Time.time;
		}

		#endregion

		if (doubleTapD) {
			Debug.Log("DoubleTapD");
		}
	}
}
