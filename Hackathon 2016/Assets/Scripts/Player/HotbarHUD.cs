using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotbarHUD : MonoBehaviour {

	public HotbarHUDElement[] elements;

	public void Start() {
		Select(0);
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < elements.Length; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha0 + i)) {
				Select(i - 1);
			}
		}
	}

	void Select(int number) {
		elements[number].Select();
		for (int i = 0; i < elements.Length; i++) {
			if (i == number) {
				continue;
			}

			elements[i].DeSelect();
		}
	}
}
