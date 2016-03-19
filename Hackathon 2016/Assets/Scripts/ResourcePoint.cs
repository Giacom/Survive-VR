using UnityEngine;
using System.Collections;

public class ResourcePoint : MonoBehaviour {

	public GameObject resourceItemPrefab;

	public int amount = 4;

	public int health = 5;

	public void Hit() {
		if (resourceItemPrefab == null) {
			Debug.LogError("Resource Item Prefab was not provided.");
			return;
		}
		if (health > 0) {
			health--;
			return;
		}

		for (int i = 0; i < amount; i++) {
			GameObject resource = Instantiate(resourceItemPrefab);
			Vector3 newPosition = transform.position;
			newPosition += (new Vector3(Random.value, Random.value, 0) * 5f);
			resource.transform.position = newPosition;
		}
		Destroy(gameObject);
	}
}
