using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
	public string Name;
	public int Damage;
	public string Deadliness;
	public string Range;
	public string Grips;
	public List<string> Keywords;

	public WeaponData(string name, int damage, string deadliness, string range, string grip, List<string> keywords)
	{
		Name = name;
		Damage = damage;
		Deadliness = deadliness;
		Range = range;
		Grips = grip;
		Keywords = keywords;
	}
}
