using UnityEngine;
using System.Collections.Generic;

public class Interaction : MonoBehaviour {

	public float interactDistance = 20f;

	public void Update() {

		if (Input.GetKeyDown(KeyCode.E)) {
			var interactingObjects = GetInteractObjects();
            Debug.LogError(interactingObjects.Count + " is the number of raycast objects that we found.");

            for (int i = 0; i < interactingObjects.Count; i++) {
				var interactingObject = interactingObjects[i];
                Debug.LogError("Checking " + interactingObject.gameObject.name);
                foreach (var interactible in interactingObject.GetComponents<IInteractible>()) {
                    Debug.LogError("Our gameobject " + interactingObject.name + " is NOT null.");

                    interactible.Activate(gameObject);
                }
			}
		}
	}

	public List<GameObject> GetInteractObjects() {
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));
		RaycastHit[] hitInfos = null;

		List<GameObject> interactedObjects = new List<GameObject>();

		hitInfos = Physics.RaycastAll(ray, interactDistance);
	
		for (int i = 0; i < hitInfos.Length; i++) {
			interactedObjects.Add(hitInfos[i].transform.gameObject);
		}
		return interactedObjects;
	}
}
