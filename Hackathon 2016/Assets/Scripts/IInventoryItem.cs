using UnityEngine;
using System.Collections;

public interface IInventoryItem {
	Sprite GetIcon();

	void Pickup();
	void Drop();

	void Select();
	void DeSelect();
}
