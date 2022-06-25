using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//equipment and stats. keyword popup
//list of items
//text box of unsorted items

public class ItemCanvas : CanvasBase
{
	public WeaponDisplay WeaponDisplayPrefab;
	public Transform WeaponRoot;

	public ArmorDisplay ArmorDisplayPrefab;
	public Transform ArmorRoot;

	public TMP_InputField Koku;
	public TMP_InputField Bu;
	public TMP_InputField Zeni;
	public TMP_InputField OtherItems;

	public override void GameInstance_OnGameStateChanged (GameState state)
	{
		SetVisible(false);
	}

	public override void SetVisible (bool visible)
	{
		base.SetVisible (visible);
		if (!visible){return;}

		DisplayList();
	}

	public void DisplayList()
	{
		var weapons = GameInstance.Instance.LoadedCharacterData.Weapons;

		WeaponRoot.DestroyChildren();

		foreach(var v in weapons)
		{
			var go = Instantiate(WeaponDisplayPrefab,WeaponRoot);
			go.GetComponent<WeaponDisplay>().SetData(v);
		}


		var armor = GameInstance.Instance.LoadedCharacterData.Armor;

		ArmorRoot.DestroyChildren();

		foreach(var v in armor)
		{
			var go = Instantiate(ArmorDisplayPrefab,ArmorRoot);
			go.GetComponent<ArmorDisplay>().SetData(v);
		}

		Koku.text = GameInstance.Instance.LoadedCharacterData.CurrentKoku.ToString();
		Bu.text = GameInstance.Instance.LoadedCharacterData.CurrentBu.ToString();
		Zeni.text = GameInstance.Instance.LoadedCharacterData.CurrentZeni.ToString();

		OtherItems.text = GameInstance.Instance.LoadedCharacterData.OtherItems;
	}

	public void SetKoku(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentKoku = int.Parse(str);
	}
	public void SetBu(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentBu = int.Parse(str);
	}
	public void SetZeni(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentZeni = int.Parse(str);
	}
	public void SetOther(string str)
	{
		GameInstance.Instance.LoadedCharacterData.OtherItems = str;
	}

}
