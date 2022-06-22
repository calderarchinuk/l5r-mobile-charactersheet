using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public static class ExtensionMethods
{
	public static Transform Search(this Transform transform, string childName)
	{
		return InternalSearch(transform,childName);
	}

	static Transform InternalSearch(Transform t, string searchName)
	{
		if (t.name == searchName){return t;}

		for (int i = 0; i < t.childCount; i++)
		{
			Transform found = InternalSearch(t.GetChild(i),searchName);
			if (found != null){return found;}
		}
		return null;
	}

	public static float HalfHeight(this Collider2D c2d)
	{
		var bc2d = c2d as BoxCollider2D;
		if (bc2d != null)
		{
			return bc2d.size.y/2;
		}
		var cc2d = c2d as CircleCollider2D;
		if (cc2d != null)
		{
			return cc2d.radius;
		}
		return 0;
	}

	public static Vector3 ToVector3(this Vector2 v2)
	{
		return new Vector3(v2.x,v2.y,0);
	}

	public static Vector2 ToVector2(this Vector3 v3)
	{
		return new Vector2(v3.x,v3.y);
	}

	//http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
	public static void Shuffle<T>(this IList<T> myList)
	{
		System.Random rng = new System.Random();
		int n = myList.Count;
		while (n>1)
		{
			n--;
			int k = rng.Next(n+1);
			T temp = myList[k];
			myList[k] = myList[n];
			myList[n] = temp;
		}
	}

	/*public static bool ContainsItem(this List<Item> itemList, Type itemType)
	{
		for (int i = 0; i<itemList.Count; i++)
		{
			if (itemList[i].GetType() == itemType){return true;}
		}
		return false;
	}*/

	public static bool TryParse<T>(this Enum theEnum, string valueToParse, out T returnValue)
	{
		returnValue = default(T);    
		if (Enum.IsDefined(typeof(T), valueToParse))
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
			returnValue = (T)converter.ConvertFromString(valueToParse);
			return true;
		}
		return false;
	}


	//http://stackoverflow.com/questions/93744/most-common-c-sharp-bitwise-operations-on-enums
	public static bool Has<T>(this System.Enum type, T value) {
		try {
			return (((int)(object)type & (int)(object)value) == (int)(object)value);
		} 
		catch {
			return false;
		}
	}

	/// <summary>
	/// Gets or add a component. Usage example:
	/// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
	/// </summary>
	public static T GetOrAddComponent<T> (this UnityEngine.Component child) where T: UnityEngine.Component {
		T result = child.GetComponent<T>();
		if (result == null) {
			result = child.gameObject.AddComponent<T>();
		}
		return result;
	}

	static Dictionary<string,Type> components = new Dictionary<string, Type>();
	/// <summary>
	/// Adds a component by string. Should only be used when parsing data from text file to build an actor
	/// </summary>
	/// <returns>The component.</returns>
	/// <param name="gameobject">Gameobject.</param>
	/// <param name="componentName">Component name.</param>
	public static UnityEngine.Component LoadComponent(this GameObject gameobject, string componentName)
	{
		if (!components.ContainsKey(componentName))
		{
			Type t = Type.GetType(componentName);
			components.Add(componentName,t);
		}
		return gameobject.AddComponent(components[componentName]);
	}

	//https://stackoverflow.com/questions/5899171/is-there-anyway-to-handy-convert-a-dictionary-to-string
	public static string ToDebugString<TKey, TValue> (this IDictionary<TKey, TValue> dictionary)
	{
		//return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}";
		return string.Join("\n", dictionary.Select(kv => kv.Key + " : " + kv.Value).ToArray());
	}

	public static Vector3 DirectionTo(this Vector3 src, Vector3 To)
	{
		return (To-src);
	}

	public static bool Contains(this string[] strings, string search)
	{
		for(int i = 0; i< strings.Length; i++)
		{
			if (strings[i] == search)
			{
				return true;
			}
		}
		return false;
	}

	public static void SetPositions(this LineRenderer line, Vector2[] positions)
	{
		var v3points = new List<Vector3>();
		for(int i = 0; i< positions.Length;i++)
		{
			v3points.Add(positions[i]);
		}
		line.SetPositions(v3points.ToArray());
	}

	public static void DestroyChildren(this Transform target)
    {
		int count = target.childCount;
		for (int i = 0; i < count; i++)
			GameObject.Destroy(target.GetChild(i).gameObject);
    }
}