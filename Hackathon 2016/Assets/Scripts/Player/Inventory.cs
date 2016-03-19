using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public const int INVENTORY_SIZE = 9;

	public HotbarHUD hotbarHUD;

	private IInventoryItem[] inventory = new IInventoryItem[INVENTORY_SIZE];

	public int currentSelectionIndex = 0;

	public bool PickupItem(IInventoryItem item) {
		int availableIndex = GetAvailableSpace();
		if (availableIndex < 0) {
			return false;
		}

		hotbarHUD.SetIcon(availableIndex, item.GetIcon());
		return true;
	}

	public bool DropItem(IInventoryItem item) {
		int itemToDropIndex = GetItemIndex(item);
		if (itemToDropIndex < 0) {
			Debug.LogError("Attempting to drop item we do not have. This should not be possible.");
			return false;
		}

		hotbarHUD.ClearIcon(itemToDropIndex);
		return true;
	}

	public void OnSelect(int newSelectionIndex) {
		if (inventory[newSelectionIndex] != null) {
			inventory[newSelectionIndex].Select();
		}

		currentSelectionIndex = newSelectionIndex;
	
		for (int i = 0; i < INVENTORY_SIZE; i++) {
			if (i == newSelectionIndex) {
				continue;
			}
			if (inventory[i] != null) {
				inventory[i].DeSelect();
			}
		}
	}

	public int GetItemIndex(IInventoryItem item) {
		for (int i = 0; i < INVENTORY_SIZE; i++) {
			if (inventory[i] == item) {
				return i;
			}
		}
		return -1;
	}

	public int GetAvailableSpace() {
		for (int i = 0; i < INVENTORY_SIZE; i++) {
			if (inventory[i] == null) {
				return i;
			}
		}
		return -1;
	}
}
