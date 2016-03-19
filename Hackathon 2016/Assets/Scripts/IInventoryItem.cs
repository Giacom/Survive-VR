using UnityEngine;
using System.Collections;

public interface IInventoryItem {
	Sprite GetIcon();
	ItemType GetItemType();

	void Pickup(Inventory inventory);
	void Drop(Inventory inventory);
	void Destroy();

	void Select();
	void DeSelect();
}
