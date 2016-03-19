using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Crafting : MonoBehaviour {

	public CraftableItem[] craftingPrefabs;

	private bool isCrafting = false;

	private int currentCraftSelection = 0;
	private int previousCraftSelection = 0;

	private CraftableItem currentSelectedCraftingObject;
	private Inventory inventory;

	public void Awake() {
		inventory = GetComponent<Inventory>();
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.C)) {
			isCrafting = !isCrafting;
		}

		if (Input.GetKeyDown(KeyCode.F)) {
			currentCraftSelection = (int)Mathf.Repeat(currentCraftSelection - 1, craftingPrefabs.Length);
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			currentCraftSelection = (int)Mathf.Repeat(currentCraftSelection + 1, craftingPrefabs.Length);
		}

		if (Input.GetKeyDown(KeyCode.B)) {
			BuildObject();
			return;
		}

		if (isCrafting) {
			UpdateCurrentSelection();
		} else if (currentSelectedCraftingObject != null) {
			DestroyObject();
		}
	}
	public void UpdateCurrentSelection() {
		if (previousCraftSelection != currentCraftSelection) {
			DestroyObject();
		}

		if (currentSelectedCraftingObject == null) {
			currentSelectedCraftingObject = Instantiate<CraftableItem>(craftingPrefabs[currentCraftSelection]);
			currentSelectedCraftingObject.transform.SetParent(gameObject.transform);
			currentSelectedCraftingObject.transform.position = (transform.position + (transform.forward * 10f) - (transform.up * 2f)) + currentSelectedCraftingObject.positionOffset;
			Renderer renderer = currentSelectedCraftingObject.GetComponent<Renderer>();

			if (renderer != null) {
				renderer.material.color = Color.green;
			}
		}

		previousCraftSelection = currentCraftSelection;
	}

	public void DestroyObject() {
		Destroy(currentSelectedCraftingObject.gameObject);
		currentSelectedCraftingObject = null;
	}

	public void BuildObject() {
		if (currentSelectedCraftingObject != null) {

			List<IInventoryItem> items = inventory.GetItems();
			int resourceItems = 0;

			for (int i = 0; i < items.Count; i++) {
				if (items[i].GetItemType() == currentSelectedCraftingObject.resourceTypeRequired) {
					resourceItems++;
				}
			}

			if (resourceItems < currentSelectedCraftingObject.resourceAmountRequired) {
				return;
			}

			int amountToRemove = 0;

			for (int i = 0; i < items.Count; i++) {
				if (items[i].GetItemType() == currentSelectedCraftingObject.resourceTypeRequired) {
					amountToRemove++;

					inventory.DestroyItem(items[i]);

					if (amountToRemove == currentSelectedCraftingObject.resourceAmountRequired) {
						break;
					}
				}
			}

			currentSelectedCraftingObject.transform.SetParent(null, true);
			Renderer renderer = currentSelectedCraftingObject.GetComponent<Renderer>();
			if (renderer != null) {
				renderer.material.color = Color.white;
			}
			currentSelectedCraftingObject = null;
			isCrafting = false;
		}
	}
}
