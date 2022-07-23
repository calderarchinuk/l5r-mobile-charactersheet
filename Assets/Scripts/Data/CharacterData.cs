using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
	//header
	public string Name;
	public int Glory;
	public int Honor;
	public int Status;
	public int Vigilance;
	public int Focus;

	public int AirRing;
	public int EarthRing;
	public int FireRing;
	public int WaterRing;
	public int VoidRing;

	public int Endurance;
	public int CurrentFatigue;

	public int Composure;
	public int CurrentStrife;

	public int MaxVoid;
	public int CurrentVoid;

	public List<DistinctionData> Distinctions = new List<DistinctionData>();

	public List<SkillData> Skills = new List<SkillData>();
	public List<TechniqueData> Techniques = new List<TechniqueData>();
	public List<ArmorData> Armor = new List<ArmorData>();
	public List<WeaponData> Weapons = new List<WeaponData>();

	public int CurrentKoku;
	public int CurrentBu;
	public int CurrentZeni;
	public string OtherItems;

	public int FreeXP;
	public int SpentXP;
	public int TotalXP;

	public string Serialize ()
	{
		string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this,Newtonsoft.Json.Formatting.Indented);
		return jsonData;
	}
}
