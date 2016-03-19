using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotbarHUD : MonoBehaviour {

	public HotbarHUDElement[] elements;
	public Inventory linkedInventory;

	public void Start() {
		Select(0);
	}

	// Update is called once per frame
	public void Update () {
		for (int i = 1; i < elements.Length + 1; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha0 + i)) {
				Select(i - 1);
			}
		}
	}

	public void Select(int number) {
		elements[number].Select();
		for (int i = 0; i < elements.Length; i++) {
			if (i == number) {
				continue;
			}

			elements[i].DeSelect();
		}

		linkedInventory.OnSelect(number);
	}

	public void SetIcon(int index, Sprite icon) {
		elements[index].SetIcon(icon);
	}

	public void ClearIcon(int index) {
		elements[index].ClearIcon();
	}
}
