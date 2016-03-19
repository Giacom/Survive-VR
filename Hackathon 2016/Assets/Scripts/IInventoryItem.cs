using UnityEngine;
using System.Collections;

public interface IInventoryItem {
	Sprite GetIcon();

	void Pickup(Inventory inventory);
	void Drop(Inventory inventory);

	void Select();
	void DeSelect();
}
