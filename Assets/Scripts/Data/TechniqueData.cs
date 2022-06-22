using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//consider also including basic actions (attack, guard)

[System.Serializable]
public class TechniqueData
{
	///show display the 'effect' string
	public bool ActionTechnique;
	public string Name;
	public string Type; //kata, shuji, ritual, nijitsu, 
	public string Book; //where to find this source + page

	public string Activation; //check for actions, condition for opportunity
	public string Effect; //text for actions
	public string Opportunity; //text
	public Ring Ring;

	public TechniqueData(string name, string activation, string effect, string opportunity, Ring ring)
	{
		Name = name;
		Activation = activation;
		Effect = effect;
		Opportunity = opportunity;
		Ring = ring;
	}
}
