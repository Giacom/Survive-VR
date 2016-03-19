using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HotbarHUDElement : MonoBehaviour {

	public Color selectedColor;

	private Image panel;
	private Image icon;

	private Color initialColor;

	public void Awake() {
		panel = GetComponent<Image>();
		icon = transform.GetChild(0).GetComponent<Image>();
		initialColor = panel.color;
	}

	public void Select() {
		panel.color = selectedColor;
	}

	public void DeSelect() {
		panel.color = initialColor;
	}

	public void SetIcon(Sprite sprite) {
		icon.enabled = true;
		icon.sprite = sprite;
	}

	public void ClearIcon() {
		icon.enabled = false;
		icon.sprite = null;
	}
}
