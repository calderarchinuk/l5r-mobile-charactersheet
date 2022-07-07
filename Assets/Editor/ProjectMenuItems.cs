using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ProjectMenuItems
{
	[MenuItem("Tools/Debug New Character Json")]
	public static void NewCharacterJson()
	{
		var characterData = new CharacterData();
		characterData.Name = "hito nami";
		characterData.AirRing = Random.Range(1,5);
		characterData.EarthRing = Random.Range(1,5);
		characterData.FireRing = Random.Range(1,5);
		characterData.WaterRing = Random.Range(1,5);
		characterData.VoidRing = Random.Range(1,5);
		characterData.MaxVoid = 1;
		characterData.Endurance = 8;
		characterData.Composure = 8;
		characterData.Vigilance = 2;
		characterData.Focus = 1;

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

		characterData.Techniques.Add(new TechniqueData("school ability name","for each $strife up to school rank, add a kept $opportunity","","",Ring.None));
		characterData.Techniques.Add(new TechniqueData("fire technique name","some activation rules","some effect notes","$fire$opportunity: example opportunity",Ring.Fire));
		characterData.Techniques.Add(new TechniqueData("water technique name","some activation rules","some effect notes","$water$opportunity+: this is an opportunity",Ring.Water));
		characterData.Techniques.Add(new TechniqueData("void technique name","some activation rules","","$opportunity$opportunity: this is an opportunity",Ring.Void));

		characterData.Distinctions.Add(new DistinctionData("giri (duty)",Ring.None,"follow lord's orders",DistinctionType.GiriDuty));
		characterData.Distinctions.Add(new DistinctionData("ninjo (desire)",Ring.None,"wants to rule the world",DistinctionType.NinjoDesire));
		characterData.Distinctions.Add(new DistinctionData("provocation",Ring.Fire,"likes to start fights. also likes to end fights. recover strife",DistinctionType.Passion));
		characterData.Distinctions.Add(new DistinctionData("blunt",Ring.Air,"is blunt. reroll some dice",DistinctionType.Disadvantage));

		characterData.Armor.Add(new ArmorData("leather",1,new List<string>(){"durable"}));
		characterData.Armor.Add(new ArmorData("plate",5,new List<string>(){"heavy","wargear"}));

		characterData.Weapons.Add(new WeaponData("sword",2,"5/7","1","1/2",new List<string>(){"razor edged","fashionable","damaged"}));
		characterData.Weapons.Add(new WeaponData("bow",1,"3","2-5","2",new List<string>(){}));

		characterData.CurrentKoku = 1;
		characterData.CurrentBu = 4;
		characterData.CurrentZeni = 5;
		characterData.OtherItems = "a long rope\nhopes and dreams\nfsteak";

		var contents = characterData.Serialize();
		Debug.Log(contents);

		var debugPath = Application.streamingAssetsPath+"/"+characterData.Name+".txt";
		Debug.Log(characterData.Name + " wrote to path "+ debugPath);
		System.IO.File.WriteAllText(debugPath,contents);
		AssetDatabase.Refresh();
	}
}
