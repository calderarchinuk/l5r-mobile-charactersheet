using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class ProjectMenuItems
{
	//[MenuItem("Tools/Debug New Character Json")]
	public static void NewCharacterJson()
	{
		var debugPath = Application.streamingAssetsPath+"/editor_test.txt";

		var characterData = new CharacterData();
		characterData.Name = "name";
		characterData.AirRing = Random.Range(1,5);
		characterData.EarthRing = Random.Range(1,5);
		characterData.FireRing = Random.Range(1,5);
		characterData.WaterRing = Random.Range(1,5);
		characterData.VoidRing = Random.Range(1,5);
		characterData.MaxVoid = 2;
		characterData.Endurance = 14;
		characterData.Composure = 14;
		characterData.Vigilance = 1;
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


		characterData.Techniques.Add(new TechniqueData("technique name","my activation text","some effect notes or whatever","this is an opportunity",Ring.Void));
		characterData.Techniques.Add(new TechniqueData("technique name","my activation text","some effect notes or whatever","this is an opportunity",Ring.Void));

		characterData.Distinctions.Add(new DistinctionData("giri",Ring.None,"follow lord's orders",DistinctionType.GiriDuty));
		characterData.Distinctions.Add(new DistinctionData("ninjo",Ring.None,"wants to rule the world",DistinctionType.NinjoDesire));
		characterData.Distinctions.Add(new DistinctionData("provocation",Ring.Fire,"likes to start fights. also likes to end fights. recover 3 strife",DistinctionType.Passion));
		characterData.Distinctions.Add(new DistinctionData("blunt",Ring.Air,"is blunt",DistinctionType.Disadvantage));

		//characterData.d.Add(new TechniqueData("lord akodo's roar","my activation text","some effect notes or whatever","this is an opportunity",Ring.Void));
		characterData.Armor.Add(new ArmorData("leather",1,new List<string>(){"durable","sad"}));
		characterData.Armor.Add(new ArmorData("plate",5,new List<string>(){"heavy","smelly","wargear"}));

		characterData.Weapons.Add(new WeaponData("katana",10,"5/7","1","1/2",new List<string>(){"razor edged","fashionable","damaged"}));

		characterData.CurrentKoku = 1;
		characterData.CurrentBu = 4;
		characterData.CurrentZeni = 5;
		characterData.OtherItems = "a long rope\nhopes and dreams\nfsteak";

		var contents = characterData.Serialize();
		Debug.Log(contents);

		Debug.Log(characterData.Name + " wrote to path "+ debugPath);
		System.IO.File.WriteAllText(debugPath,contents);
	}
}
