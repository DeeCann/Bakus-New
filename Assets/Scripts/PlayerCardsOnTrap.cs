using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCardsOnTrap : MonoBehaviour {

    public void RegisterListener(trapsPanelControler manager) {
        Button myButton = GetComponent<Button>();
        if(GetComponent<Image>().sprite.name != "Empty")
            myButton.onClick.AddListener(() => { manager.ChooseCard(this.gameObject.name); });
    }
}
