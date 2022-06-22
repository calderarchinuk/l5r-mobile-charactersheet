using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//consider putting a mark on these if a distinction or technique are relevant

[System.Serializable]
public class SkillData
{
	public string Group;
	public string Name;
	public int Level;

	public SkillData(string name, string group, int level)
	{
		Name = name;
		Level = level;
		Group = group;
	}
}
