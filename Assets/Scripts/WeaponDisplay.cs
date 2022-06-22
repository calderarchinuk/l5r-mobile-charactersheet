using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
	public TextMeshProUGUI Name;
	public TextMeshProUGUI Damage;
	public TextMeshProUGUI Deadliness;
	public TextMeshProUGUI Range;
	public TextMeshProUGUI Grip;
	public TextMeshProUGUI Keywords;

	public void SetData(WeaponData data)
	{
		Name.text = data.Name;
		Damage.text = data.Damage.ToString();
		Deadliness.text = data.Deadliness;
		Range.text = data.Range;
		Grip.text = data.Grips;
		string s = "";
		for(int i = 0;i<data.Keywords.Count;i++)
		{
			if (i != 0)
			{
				s+=", ";
			}
			s += data.Keywords[i];
		}
		Keywords.text = s;
	}
}
