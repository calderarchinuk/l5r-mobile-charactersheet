using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TechniqueDataHolder
{
	public string guid;
	public TechniqueData data;
	public bool foldout;
	public bool darkBackground;
	public TechniqueDataHolder(TechniqueData data, bool darkBackground, bool defaultVisible)
	{
		guid = System.Guid.NewGuid().ToString();
		this.data = data;
		this.darkBackground = darkBackground;
		foldout = defaultVisible;
	}
}

public class DistinctionDataHolder
{
	public string guid;
	public DistinctionData data;
	public bool foldout;
	public bool darkBackground;
	public DistinctionDataHolder(DistinctionData data, bool darkBackground, bool defaultVisible)
	{
		guid = System.Guid.NewGuid().ToString();
		this.data = data;
		this.darkBackground = darkBackground;
		foldout = defaultVisible;
	}
}

public class CharacterEditorWindow : EditorWindow
{
	[MenuItem("Tools/Character Editor")]
	static void Init()
	{
		CharacterEditorWindow window = (CharacterEditorWindow)EditorWindow.GetWindow(typeof(CharacterEditorWindow));
		window.Show();
	}

	List<TechniqueDataHolder> displayTechniques = new List<TechniqueDataHolder>();
	List<DistinctionDataHolder> displayDistinctions = new List<DistinctionDataHolder>();

	CharacterData characterData;
	bool skillFoldOut;
	bool techniquesFoldOut;
	bool distinctionsFoldOut;
	bool itemsFoldOut;
	Vector2 scollPosition;

	void OnGUI()
	{
		GUI.skin.textArea.wordWrap = true;
		GUIStyle foldoutStyle = new GUIStyle(EditorStyles.foldout);
		foldoutStyle.fixedWidth = 5;

		//new/load options
		if (characterData == null)
		{
			foreach(var v in GetFiles())
			{
				if (GUILayout.Button(v))
				{
					LoadCharacter(v);
				}
			}
			if (GUILayout.Button("New Character Data"))
			{
				NewCharacterData();
			}
			return;
		}
			
		GUILayout.BeginHorizontal();
		characterData.Name = EditorGUILayout.TextField("Name",characterData.Name);
		if (GUILayout.Button("Save"))
		{
			SaveCharacterData(characterData.Name);
		}
		GUILayout.EndHorizontal();

		EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

		EditorGUILayout.BeginHorizontal();
		GUILayout.BeginVertical();
		characterData.AirRing = EditorGUILayout.IntField("Air",characterData.AirRing);
		characterData.EarthRing = EditorGUILayout.IntField("Earth",characterData.EarthRing);
		characterData.FireRing = EditorGUILayout.IntField("Fire",characterData.FireRing);
		characterData.WaterRing = EditorGUILayout.IntField("Water",characterData.WaterRing);
		characterData.VoidRing = EditorGUILayout.IntField("Void",characterData.VoidRing);
		EditorGUILayout.EndVertical();

		EditorGUILayout.BeginVertical();
		characterData.Glory = EditorGUILayout.IntField("Glory",characterData.Glory);
		characterData.Honor = EditorGUILayout.IntField("Honor",characterData.Honor);
		characterData.Status = EditorGUILayout.IntField("Status",characterData.Status);
		characterData.Vigilance = EditorGUILayout.IntField("Vigilance",characterData.Vigilance);
		characterData.Focus = EditorGUILayout.IntField("Focus",characterData.Focus);
		GUILayout.EndVertical();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		characterData.Endurance = EditorGUILayout.IntField("Endurance",characterData.Endurance);
		characterData.Composure = EditorGUILayout.IntField("Composure",characterData.Composure);
		characterData.MaxVoid = EditorGUILayout.IntField("Max Void Points",characterData.MaxVoid);
		EditorGUILayout.EndHorizontal();

		skillFoldOut = EditorGUILayout.Foldout(skillFoldOut,"Skills");
		if (skillFoldOut)
		{
			//skills
			for(int i = 0; i< characterData.Skills.Count;i++)
			{
				characterData.Skills[i].Level = EditorGUILayout.IntField(characterData.Skills[i].Name,characterData.Skills[i].Level);
			}
		}

		scollPosition = GUILayout.BeginScrollView(scollPosition);

		//TODO hint about inlining icons with $earth, $strife, etc
		GUILayout.BeginHorizontal();
		techniquesFoldOut = EditorGUILayout.Foldout(techniquesFoldOut,"Techniques");
		if (techniquesFoldOut && GUILayout.Button("New Technique"))
		{
			var newTech = new TechniqueData("","","","",Ring.None);
			characterData.Techniques.Add(newTech);
			displayTechniques.Add(new TechniqueDataHolder(newTech,characterData.Techniques.Count%2==0,true));
		}
		GUILayout.EndHorizontal();
		if (techniquesFoldOut)
		{
			EditorGUI.indentLevel++;
			for(int i = 0 ;i<displayTechniques.Count;i++)
			{
				//EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);
				GUILayout.BeginHorizontal();
				displayTechniques[i].foldout = EditorGUILayout.Foldout(displayTechniques[i].foldout,"");
				characterData.Techniques[i].Name = GUILayout.TextField(characterData.Techniques[i].Name,GUILayout.Width(100));
				characterData.Techniques[i].Ring = (Ring)EditorGUILayout.EnumPopup(characterData.Techniques[i].Ring,GUILayout.Width(50));
				EditorGUILayout.LabelField("",GUI.skin.horizontalSlider,GUILayout.ExpandWidth(true));

				if (GUILayout.Button("Delete",GUILayout.Width(50)))
				{
					var removeTech = displayTechniques.Find(delegate(TechniqueDataHolder obj) {
						return obj.data == characterData.Techniques[i];
					});
					if (removeTech != null)
					{
						displayTechniques.Remove(removeTech);
						characterData.Techniques.RemoveAt(i);return;
					}
				}
				GUILayout.EndHorizontal();

				if (displayTechniques[i].foldout)
				{
					GUILayout.Label("Activation");
					characterData.Techniques[i].Activation = GUILayout.TextArea(characterData.Techniques[i].Activation);
					GUILayout.Label("Effect");
					characterData.Techniques[i].Effect = GUILayout.TextArea(characterData.Techniques[i].Effect);
					GUILayout.Label("Opportunities");
					characterData.Techniques[i].Opportunity = GUILayout.TextArea(characterData.Techniques[i].Opportunity);
				}
			}
			EditorGUI.indentLevel--;
		}

		//distinctions
		GUILayout.BeginHorizontal();
		distinctionsFoldOut = EditorGUILayout.Foldout(distinctionsFoldOut,"Distinctions");
		if (distinctionsFoldOut && GUILayout.Button("New Distinction"))
		{
			var newDist = new DistinctionData("",Ring.None,"",DistinctionType.Distinction);
			characterData.Distinctions.Add(newDist);
			displayDistinctions.Add(new DistinctionDataHolder(newDist,characterData.Distinctions.Count%2==0,true));
		}
		GUILayout.EndHorizontal();
		if (distinctionsFoldOut)
		{
			EditorGUI.indentLevel++;
			for(int i = 0 ;i<displayDistinctions.Count;i++)
			{
				GUILayout.BeginHorizontal();
				displayDistinctions[i].foldout = EditorGUILayout.Foldout(displayDistinctions[i].foldout,"");
				characterData.Distinctions[i].Name = GUILayout.TextField(characterData.Distinctions[i].Name,GUILayout.Width(100));
				characterData.Distinctions[i].Ring = (Ring)EditorGUILayout.EnumPopup(characterData.Distinctions[i].Ring,GUILayout.Width(50));
				GUILayout.FlexibleSpace();
				if (GUILayout.Button("Delete",GUILayout.Width(50)))
				{
					var removeTech = displayDistinctions.Find(delegate(DistinctionDataHolder obj) {
						return obj.data == characterData.Distinctions[i];
					});
					if (removeTech != null)
					{
						displayDistinctions.Remove(removeTech);
						characterData.Distinctions.RemoveAt(i);return;
					}
				}
				GUILayout.EndHorizontal();
				if (displayDistinctions[i].foldout)
				{
					GUILayout.Label("Description");
					characterData.Distinctions[i].Description = GUILayout.TextArea(characterData.Distinctions[i].Description);
				}
			}
			EditorGUI.indentLevel--;
		}

		//armor
		//secondary popup window? or just in-line with the character sheet?
		GUILayout.BeginHorizontal();
		itemsFoldOut = EditorGUILayout.Foldout(itemsFoldOut,"Items");
		if (itemsFoldOut && GUILayout.Button("New Armor"))
		{
			characterData.Armor.Add(new ArmorData("",0,new List<string>()));
		}
		if (itemsFoldOut && GUILayout.Button("New Weapon"))
		{
			characterData.Weapons.Add(new WeaponData("",0,"","","",new List<string>()));
		}
		GUILayout.EndHorizontal();
		if (itemsFoldOut)
		{
			//header
			GUILayout.BeginHorizontal();
			GUILayout.Label("name",GUILayout.Width(100));
			GUILayout.Label("defense",GUILayout.Width(50));
			GUILayout.EndHorizontal();

			for(int i = 0 ;i<characterData.Armor.Count;i++)
			{
				GUILayout.BeginHorizontal();
				characterData.Armor[i].Name = GUILayout.TextField(characterData.Armor[i].Name,GUILayout.Width(100));
				characterData.Armor[i].Defense = EditorGUILayout.IntField(characterData.Armor[i].Defense,GUILayout.Width(50));
				GUILayout.BeginVertical();
				GUIx.StringList("keywords",characterData.Armor[i].Keywords);
				GUILayout.EndVertical();
				if (GUILayout.Button("Delete",GUILayout.Width(50))){characterData.Armor.RemoveAt(i);return;}
				GUILayout.EndHorizontal();
			}

			EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

			//header
			GUILayout.BeginHorizontal();
			GUILayout.Label("name",GUILayout.Width(50));
			GUILayout.Label("damage",GUILayout.Width(50));
			GUILayout.Label("deadliness",GUILayout.Width(50));
			GUILayout.Label("range",GUILayout.Width(50));
			GUILayout.Label("grips",GUILayout.Width(50));
			GUILayout.Label("damage",GUILayout.Width(50));
			GUILayout.EndHorizontal();

			for(int i = 0 ;i<characterData.Weapons.Count;i++)
			{
				GUILayout.BeginHorizontal();

				characterData.Weapons[i].Name = GUILayout.TextField(characterData.Weapons[i].Name,GUILayout.Width(50));
				characterData.Weapons[i].Damage = EditorGUILayout.IntField(characterData.Weapons[i].Damage,GUILayout.Width(50));

				characterData.Weapons[i].Deadliness = GUILayout.TextField(characterData.Weapons[i].Deadliness,GUILayout.Width(50));
				characterData.Weapons[i].Range = GUILayout.TextField(characterData.Weapons[i].Range,GUILayout.Width(50));
				characterData.Weapons[i].Grips = GUILayout.TextField(characterData.Weapons[i].Grips,GUILayout.Width(50));
				GUILayout.BeginVertical();
				GUIx.StringList("keywords",characterData.Weapons[i].Keywords);
				GUILayout.EndVertical();
				if (GUILayout.Button("Delete",GUILayout.Width(50))){characterData.Weapons.RemoveAt(i);return;}
				GUILayout.EndHorizontal();
			}

			EditorGUILayout.LabelField("",GUI.skin.horizontalSlider);

			//money
			characterData.CurrentKoku = EditorGUILayout.IntField("koku",characterData.CurrentKoku);
			characterData.CurrentBu = EditorGUILayout.IntField("bu",characterData.CurrentBu);
			characterData.CurrentZeni = EditorGUILayout.IntField("zeni",characterData.CurrentZeni);

			GUILayout.Label("other items");
			characterData.OtherItems = GUILayout.TextArea(characterData.OtherItems);
		}

		GUILayout.EndScrollView();
	}

	void NewCharacterData()
	{
		characterData = new CharacterData();

		characterData.Skills.Add(new SkillData("Aesthetics","Artisan",0));
		characterData.Skills.Add(new SkillData("Composition","Artisan",0));
		characterData.Skills.Add(new SkillData("Design","Artisan",0));
		characterData.Skills.Add(new SkillData("Smithing","Artisan",0));

		characterData.Skills.Add(new SkillData("Command","Social",0));
		characterData.Skills.Add(new SkillData("Courtesy","Social",0));
		characterData.Skills.Add(new SkillData("Games","Social",0));
		characterData.Skills.Add(new SkillData("Performance","Social",0));

		characterData.Skills.Add(new SkillData("Commerce","Trade",0));
		characterData.Skills.Add(new SkillData("Labor","Trade",0));
		characterData.Skills.Add(new SkillData("Seafaring","Trade",0));
		characterData.Skills.Add(new SkillData("Skulduggery","Trade",0));
		characterData.Skills.Add(new SkillData("Survival","Trade",0));

		characterData.Skills.Add(new SkillData("Fitness","Martial",0));
		characterData.Skills.Add(new SkillData("Melee","Martial",0));
		characterData.Skills.Add(new SkillData("Ranged","Martial",0));
		characterData.Skills.Add(new SkillData("Unarmed","Martial",0));
		characterData.Skills.Add(new SkillData("Meditation","Martial",0));
		characterData.Skills.Add(new SkillData("Tactics","Martial",0));

		characterData.Skills.Add(new SkillData("Culture","Scholar",0));
		characterData.Skills.Add(new SkillData("Government","Scholar",0));
		characterData.Skills.Add(new SkillData("Medicine","Scholar",0));
		characterData.Skills.Add(new SkillData("Sentiment","Scholar",0));
		characterData.Skills.Add(new SkillData("Theology","Scholar",0));

	}

	string[] filesCache;
	public string[] GetFiles()
	{
		if (filesCache != null){return filesCache;}

		string DOWNLOADDIR = Application.streamingAssetsPath;

		if (Directory.Exists(DOWNLOADDIR))
		{
			//only include files that are .txt or .json or .xml
			List<string> validFiles = new List<string>();
			var files = System.IO.Directory.GetFiles(DOWNLOADDIR);
			foreach(var f in files)
			{
				if (f.EndsWith(".txt") || f.EndsWith(".json") || f.EndsWith(".xml"))
					validFiles.Add(f);
			}
			filesCache = validFiles.ToArray();
			return filesCache;
		}
		else
		{
			return new string[0];
		}
	}

	public void LoadCharacter(string filepath)
	{
		var settings = new Newtonsoft.Json.JsonSerializerSettings();
		settings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects;
		string rawData = System.IO.File.ReadAllText(filepath);
		characterData = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterData>(rawData);

		displayTechniques.Clear();
		int id = 0;
		foreach(var v in characterData.Techniques)
		{
			id ++;
			displayTechniques.Add(new TechniqueDataHolder(v,id%2==0,false));
		}

		displayDistinctions.Clear();
		id = 0;
		foreach(var v in characterData.Distinctions)
		{
			id ++;
			displayDistinctions.Add(new DistinctionDataHolder(v,id%2==0,false));
		}
	}

	public void SaveCharacterData(string characterName)
	{
		var debugPath = Application.streamingAssetsPath+"/"+characterName+".txt";
		var contents = characterData.Serialize();
		Debug.Log(contents);

		Debug.Log(characterData.Name + " wrote to path "+ debugPath);
		System.IO.File.WriteAllText(debugPath,contents);
	}
}

public class GUIx
{
	public static void StringArray (string label, ref string[] array)
	{
		if (array == null)
		{
			Debug.LogError(label + " is null!");
			array = new string[0];
		}

		GUILayout.BeginHorizontal();
		GUILayout.Label(label);
		if (GUILayout.Button("+",GUILayout.Width(20)))
		{
			ArrayUtility.Add(ref array,string.Empty);
		}
		GUILayout.EndHorizontal();
		for(int i =0;i<array.Length;i++)
		{
			GUILayout.BeginHorizontal();
			array[i] = GUILayout.TextField(array[i]);
			if (GUILayout.Button("-",GUILayout.Width(20)))
			{
				ArrayUtility.RemoveAt(ref array,i);
				GUILayout.EndHorizontal();
				break;
			}
			GUILayout.EndHorizontal();
		}
	}

	public static void StringList (string label, List<string> array)
	{
		if (array == null)
		{
			Debug.LogError(label + " is null!");
			array = new List<string>();
		}

		GUILayout.BeginHorizontal();
		GUILayout.Label(label);
		if (GUILayout.Button("+",GUILayout.Width(20)))
		{
			array.Add(string.Empty);
			//ArrayUtility.Add(ref array,string.Empty);
		}
		GUILayout.EndHorizontal();
		for(int i =0;i<array.Count;i++)
		{
			GUILayout.BeginHorizontal();
			array[i] = GUILayout.TextField(array[i]);
			if (GUILayout.Button("-",GUILayout.Width(20)))
			{
				array.RemoveAt(i);
				//ArrayUtility.RemoveAt(ref array,i);
				GUILayout.EndHorizontal();
				break;
			}
			GUILayout.EndHorizontal();
		}
	}
}