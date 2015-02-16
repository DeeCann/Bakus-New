using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	public static Dictionary<string, int> _fruitsInGame = new Dictionary<string, int> ();
	public static Dictionary<string, int> _fruitsCollected = new Dictionary<string, int> ();

	private static GameObject[] Players = new GameObject[5];
	private string[] characterNames = new string[] {"Hippo", "Tiger", "Dog", "Bear", "Frog"};
    private List<Transform> _tiles = new List<Transform>();
    private static string[] _onBoardFruitsNames = new string[] { "Apple", "Blackberry", "Blueberry", "Peach", "Raspberry", "Strawberry" };
    private static Dictionary<string, int> _myPoints = new Dictionary<string, int>() { {"Apple", 0}, {"Blackberry", 0}, {"Blueberry", 0}, {"Peach", 0}, {"Raspberry", 0}, {"Strawberry", 0} };

	private static int _playersNumber = 1;
	private static int _currentPlayerRound = 0;

	private bool _showStartFruitsAmountPanel = false;
    private static bool _playerHasSomeFruit = false;

	private static GameObject _startField;
    private Transform _tilesContainer;
    private Transform _fruitsContainer;
	private GameObject _HUDControler;

	private enum fruitsNames {
		Apple = 1,
		Raspberry = 2,
		Blueberry = 3,
		Blackberry = 4,
		Peach = 5,
		Strawberry = 6
	}

	void Awake() {
		_startField = GameObject.FindGameObjectsWithTag(Tags.StartPoint)[Random.Range(0,3)];
		_HUDControler = GameObject.FindGameObjectWithTag(Tags.HUDControler);

		for (int i = 0; i < _playersNumber; i++) {

			GameObject player = Instantiate(Resources.Load(characterNames[i]), Vector3.zero, Quaternion.identity) as GameObject;
            player.name = characterNames[i];

			player.GetComponent<PlayerRoute>().StartFieldSocket = _startField.GetComponent<FieldSocket>().TakeSocketNumber;
			player.transform.position = _startField.GetComponent<FieldSocket>().TakeSocketVectorPosition(player.GetComponent<PlayerRoute>().StartFieldSocket);;

			// special treating frog ... 0.75 height on init
			player.transform.position = new Vector3(player.transform.position.x, 0.02f, player.transform.position.z);

			player.GetComponent<PlayerCharacter>().PlayerNumber = i+1;
			Players[i] = player;

            PlayerPrefs.SetString("Player" + i, characterNames[i]);
		}



		_currentPlayerRound = 1;

		_fruitsInGame.Add (fruitsNames.Apple.ToString(), Random.Range(10,20));
		_fruitsInGame.Add (fruitsNames.Raspberry.ToString(), Random.Range(10,20));
		_fruitsInGame.Add (fruitsNames.Blueberry.ToString(), Random.Range(10,20));
		_fruitsInGame.Add (fruitsNames.Blackberry.ToString(), Random.Range(10,20));
		_fruitsInGame.Add (fruitsNames.Peach.ToString(), Random.Range(10,20));
		_fruitsInGame.Add (fruitsNames.Strawberry.ToString(), Random.Range(10,20));

        _tilesContainer = GameObject.FindGameObjectWithTag("Tiles").transform.FindChild("t1");
        _fruitsContainer = GameObject.Find("GeneratedFruitsContainer").transform;

        GenerateOnBoardFruits();
	}

	void Start() {
		Dice.CanDoDiceRoll = true;
	}

	void FixedUpdate() {
		if (!_showStartFruitsAmountPanel) {
			_HUDControler.GetComponent<HUD> ().ShowStartFruitsAmount ();
			_showStartFruitsAmountPanel = true;
		}
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

    public static string GetCurrentCharacterName
    {
        get
        {
            return Players[_currentPlayerRound - 1].name;
        }
    }

	public static void NextRound() {
		if(_currentPlayerRound == _playersNumber)
			_currentPlayerRound = 1;
		else
			_currentPlayerRound++;

		PinchZoom.ResetZoom();
	}

    public static void SetFruitPoint(string fruit, int amount) {
        _myPoints[fruit] = _myPoints[fruit] + amount;
        FruitsPanel.SetPoint(fruit, amount);
        _playerHasSomeFruit = true;
    }

    public static void RemoveRandomFruitPoint(int amount)
    {
        if (_playerHasSomeFruit)
        {
            bool foundFruitsGreaterThanZero = false;
            int fruitRandomName = 0;
            while (!foundFruitsGreaterThanZero)
            {
                fruitRandomName = Random.Range(0, 6);
                if (_myPoints[_onBoardFruitsNames[fruitRandomName]] > 0)
                {
                    _myPoints[_onBoardFruitsNames[fruitRandomName]] -= amount;
                    foundFruitsGreaterThanZero = true;
                }
            }

            FruitsPanel.SetPoint(_onBoardFruitsNames[fruitRandomName], amount * -1);
        }
    }

	public static void OpenObstaclePanel() {

	}


    /**
     * PRIVATE
     * **/
    private void GenerateOnBoardFruits()
    {
        foreach (Transform tile in _tilesContainer)
        {
            _tiles.Add(tile);
        }

        for (int i = 0; i < _onBoardFruitsNames.Length - 1; i++)
        {
            for (int j = 0; j <= 30; j++)
            {
                int randomTileNumber = Random.Range(0, _tiles.Count - 1);
                Vector3 fruitPosition = _tiles[randomTileNumber].transform.position;
                fruitPosition.y = 0.1f;
                GameObject fruit = (GameObject)Instantiate(Resources.Load("Prefabs/" + _onBoardFruitsNames[i]), fruitPosition, Quaternion.identity);
                fruit.name = _onBoardFruitsNames[i];
                fruit.transform.parent = _fruitsContainer;

                _tiles.Remove(_tiles[randomTileNumber]);
            }
        }
    }
}
