using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private static GameObject[] Players = new GameObject[5];
	private string[] characterNames = new string[] {"MainGame_Hipcio", "MainGame_Tygrys", "MainGame_Pies", "MainGame_Mis", "MainGame_Zaba"};

	private static int _playersNumber = 5;
	private static int _currentPlayerRound = 0;

	private static GameObject _startField;

	void Awake() {
		_startField = GameObject.FindGameObjectWithTag(Tags.StartPoint);

		for (int i = 0; i < _playersNumber; i++) {

			GameObject player = Instantiate(Resources.Load(characterNames[i]), Vector3.zero, Quaternion.identity) as GameObject;

			player.GetComponent<PlayerRoute>().StartFieldSocket = _startField.GetComponent<FieldSocket>().TakeSocketNumber;
			player.transform.position = _startField.GetComponent<FieldSocket>().TakeSocketVectorPosition(player.GetComponent<PlayerRoute>().StartFieldSocket);;

			// special treating frog ... 0.75 height on init
			player.transform.position = new Vector3(player.transform.position.x, 0.75f, player.transform.position.z);

			player.GetComponent<PlayerCharacter>().PlayerNumber = i+1;
			Players[i] = player;
		}

		_currentPlayerRound = 1;
	}

	void Start() {
		GameObject[] startFields = GameObject.FindGameObjectsWithTag(Tags.StartPoint);
		if(startFields.Length > 1)
			throw new UnityException("There is more tha one start");

		Dice.CanDoDiceRoll = true;
	}

	public static GameObject GetStartField {
		get{
			return _startField;
		}
	}

	public static GameObject GetCurrentPlayer {
		get{
			return Players[_currentPlayerRound - 1];
		}
	}

	public static void NextRound() {
		if(_currentPlayerRound == _playersNumber)
			_currentPlayerRound = 1;
		else
			_currentPlayerRound++;

		PinchZoom.ResetZoom();
	}
}
