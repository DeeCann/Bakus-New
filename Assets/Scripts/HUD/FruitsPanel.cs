using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FruitsPanel : MonoBehaviour {

	void Start() {
		foreach (Transform fruit in transform)
			fruit.FindChild("TextPanel").transform.FindChild("IsText").GetComponent<Text>().text = Game._fruitsInGame[fruit.name].ToString();
	}
}
