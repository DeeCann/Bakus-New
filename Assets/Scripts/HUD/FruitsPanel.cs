using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FruitsPanel : MonoBehaviour {

    private static string _setPointForFruitName;
    private static int _setPointForFruitAmount;
    private static bool _changeScore = false;

	void Start() {
        foreach (Transform fruit in transform)
			fruit.FindChild("TextPanel").transform.FindChild("IsText").GetComponent<Text>().text = Game._fruitsInGame[fruit.name].ToString();
	}

    void Update() {
        if (_changeScore) {
            int newAmount = System.Convert.ToInt16(transform.FindChild(_setPointForFruitName).FindChild("TextPanel").transform.FindChild("HasText").GetComponent<Text>().text) + _setPointForFruitAmount;
            transform.FindChild(_setPointForFruitName).FindChild("TextPanel").transform.FindChild("HasText").GetComponent<Text>().text = newAmount.ToString();

            _changeScore = false;
        }
    }
    public static void SetPoint(string fruitName, int amount) {
        _setPointForFruitName = fruitName;
        _setPointForFruitAmount = amount;

        _changeScore = true;
    }
}
