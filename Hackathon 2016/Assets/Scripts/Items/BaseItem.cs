using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour, IInventoryItem, IInteractible {
	public Sprite inventoryIcon;

	public Sprite GetIcon() {
		return inventoryIcon;
	}

	public void Activate(GameObject interactor) {
		Debug.LogError("ACTIVATE!");
		var inventory = interactor.GetComponent<Inventory>();
		if (inventory == null) {
			return;
		}

		if (!inventory.PickupItem(this)) {
			return;
		}
	}

	public virtual void Pickup() {

	}

	public virtual void Drop() {

	}

	public virtual void Select() {

	}

	public virtual void DeSelect() {

	}
}
