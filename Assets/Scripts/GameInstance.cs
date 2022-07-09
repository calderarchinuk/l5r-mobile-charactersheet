using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public enum GameState
{
	Menu,
	CharacterSheet
}

//deals with basic app stuff. file loading/saving

public class GameInstance : MonoBehaviour
{
	public static GameInstance Instance;

	public MainMenuCanvas MainMenu;
	public TechniqueCanvas Techniques;
	public ItemCanvas Items;
	public RoleplayCanvas Roleplay;
	public HeaderCanvas Header;
	public SkillCanvas Skills;
	public QuickReferenceCanvas Reference;

	public GameState GameState = GameState.Menu;

	public delegate void onGameStateChanged(GameState state);
	///after the game state has changed
	public static event onGameStateChanged OnGameStateChanged;
	public static void GameStateChangedEvent(GameState state) { if (OnGameStateChanged != null) { OnGameStateChanged(state); } }

	public string[] LoadedFiles;

	static string DOWNLOADDIR = "/sdcard/download/L5R/";
	public TextMeshProUGUI debuggui;

	string referencePath;
	List<ReferenceData> referenceData;

	public void SetPath(string path)
	{
		DOWNLOADDIR = path;
	}
	public string GetPath()
	{
		return DOWNLOADDIR;
	}

	public string[] GetFiles()
	{
		try
		{
			#if UNITY_EDITOR
			DOWNLOADDIR = Application.streamingAssetsPath+"/";
			#endif

			if (Directory.Exists(DOWNLOADDIR))
			{
				//only include files that are .txt or .json or .xml
				List<string> validFiles = new List<string>();
				var files = System.IO.Directory.GetFiles(DOWNLOADDIR);
				foreach(var f in files)
				{
					if (f.EndsWith("reference.txt") || f.EndsWith("references.txt") || f.EndsWith("reference.json") || f.EndsWith("references.json"))
					{
						referencePath = f;
						continue;
					}
					if (f.EndsWith(".txt") || f.EndsWith(".json") || f.EndsWith(".xml"))
						validFiles.Add(f);
				}
				return validFiles.ToArray();
			}
			else
			{
				return new string[0];
			}

		}
		catch(System.Exception e)
		{
			debuggui.text = e.ToString();
		}

		return new string[0];
	}

	public void LoadCharacter(string filepath)
	{
		var settings = new Newtonsoft.Json.JsonSerializerSettings();
		settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects;
		string rawData = System.IO.File.ReadAllText(filepath);
		LoadedCharacterData = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterData>(rawData);

		if (LoadedCharacterData != null)
		{
			//change game state
			//set canvases
			SetGameState(GameState.CharacterSheet);
		}
		else
		{
			//TODO try loading xml in the format cherry blossoms exports
		}
	}

	public CharacterData LoadedCharacterData{get;private set;}

	void Start()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);

		if (Application.isEditor)
		{
			DOWNLOADDIR = Application.streamingAssetsPath+"/";
		}

		Techniques.SetVisible(false);
		Items.SetVisible(false);
		Roleplay.SetVisible(false);
		Header.SetVisible(false);
		Skills.SetVisible(false);
		Reference.SetVisible(false);

		MainMenu.Initialize();
		MainMenu.SetVisible(true);
		MainMenu.DisplayCharacterList();
	}

	public static void WriteToDisk(CharacterData characterData)
	{
		if (string.IsNullOrEmpty(characterData.Name))
		{
			Debug.LogError("character doesn't have a name!");
			return;
		}

		Directory.CreateDirectory(DOWNLOADDIR);

		var contents = characterData.Serialize();
		Debug.Log(contents);

		string _path = DOWNLOADDIR+characterData.Name+".txt";
		Debug.Log(characterData.Name + " wrote to path "+ _path);
		System.IO.File.WriteAllText(_path,contents);
	}

	void SetGameState(GameState newGameState)
	{
		GameState = newGameState;
		GameStateChangedEvent(newGameState);
	}

	public List<ReferenceData> GetReferenceData()
	{
		if (referenceData == null && !string.IsNullOrEmpty(referencePath))
		{
			//try to load reference.json if the file exists
			string rawData = System.IO.File.ReadAllText(referencePath);
			referenceData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReferenceData>>(rawData);	
		}
		return referenceData;
	}

	public void Button_SetScreen(string name)
	{
		if (LoadedCharacterData != null)
			WriteToDisk(LoadedCharacterData);
		//tech, roleplay, items, skills
		Techniques.SetVisible(false);
		Roleplay.SetVisible(false);
		Items.SetVisible(false);
		Skills.SetVisible(false);
		Reference.SetVisible(false);

		switch(name)
		{
			case "tech":Techniques.SetVisible(true);break;
			case "roleplay":Roleplay.SetVisible(true);break;
			case "items":Items.SetVisible(true);break;
			case "skills":Skills.SetVisible(true);break;
			case "reference":Reference.SetVisible(true);break;
		}
	}
}
