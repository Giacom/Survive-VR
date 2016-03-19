using UnityEngine;
using System.Collections;

public class BaseItem : MonoBehaviour, IInventoryItem, IInteractible {
	public Sprite inventoryIcon;

	public Sprite GetIcon() {
		return inventoryIcon;
	}

	public void Activate(GameObject interactor) {
		var inventory = interactor.GetComponent<Inventory>();
		if (inventory == null) {
			return;
		}

		inventory.PickupItem(this);
	}

	public virtual void Pickup(Inventory inventory) {
		gameObject.SetActive(false);
		gameObject.transform.SetParent(inventory.transform);
	}

	public virtual void Drop(Inventory inventory) {
		gameObject.SetActive(true);
		gameObject.transform.SetParent(null);
		gameObject.transform.position = inventory.transform.position + (inventory.transform.forward * 2f);
	}

	public virtual void Select() {

	}

	public virtual void DeSelect() {

	}
}
