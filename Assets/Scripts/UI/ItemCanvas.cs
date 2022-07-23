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
	public TMP_InputField TotalXP;
	public TMP_InputField SpentXP;
	public TMP_InputField FreeXP;
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

		TotalXP.text = GameInstance.Instance.LoadedCharacterData.TotalXP.ToString();
		SpentXP.text = GameInstance.Instance.LoadedCharacterData.SpentXP.ToString();
		FreeXP.text = GameInstance.Instance.LoadedCharacterData.FreeXP.ToString();

		OtherItems.text = GameInstance.Instance.LoadedCharacterData.OtherItems;
	}

	public void SetKoku(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentKoku = int.Parse(str);
		GameInstance.Save();
	}
	public void SetBu(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentBu = int.Parse(str);
		GameInstance.Save();
	}
	public void SetZeni(string str)
	{
		GameInstance.Instance.LoadedCharacterData.CurrentZeni = int.Parse(str);
		GameInstance.Save();
	}
	public void SetFreeXP(string str)
	{
		GameInstance.Instance.LoadedCharacterData.FreeXP = int.Parse(str);
		GameInstance.Save();
	}
	public void SetSpentXP(string str)
	{
		GameInstance.Instance.LoadedCharacterData.SpentXP = int.Parse(str);
		GameInstance.Save();
	}
	public void SetTotalXP(string str)
	{
		GameInstance.Instance.LoadedCharacterData.TotalXP = int.Parse(str);
		GameInstance.Save();
	}
	public void SetOther(string str)
	{
		GameInstance.Instance.LoadedCharacterData.OtherItems = str;
		GameInstance.Save();
	}
}
