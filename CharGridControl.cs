using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; 
using UnityEngine;
public enum SortStyle {Empire, Level, Favourites}
public class CharGridControl : MonoBehaviour {
    SortStyle order;
    public List<Characters> availableCharacters;
    GameObject baseIcon;
    BaseControl input; 
	// Use this for initialization
	void Start () {
        order = SortStyle.Empire; 
	}
    private void Awake()
    {
       
    }
    public void SortEmpire()
    {
        baseIcon = Resources.Load<GameObject>("CharacterIcons/CharacterButton");
        Debug.Log(baseIcon); 
        input = GameObject.Find("Main Camera").GetComponent<BaseControl>();
        availableCharacters = input.availableChars;
        GameObject[,] CharEmpires = new GameObject[10,10]; 
        Debug.Log(availableCharacters.Count);
        float offsetx = -2;
        float offsety = -6; 
        int multiplier = 2;
        int vertMult = 2; 
        for (int i = 0; i < availableCharacters.Count; i++)
        {
            CharEmpires[(int)availableCharacters[i].Allegiance,(int)availableCharacters[i].CharacterClass] = Instantiate(baseIcon);
            RectTransform pos = CharEmpires[(int)availableCharacters[i].Allegiance, (int)availableCharacters[i].CharacterClass].GetComponent<RectTransform>();
            pos.position = new Vector3(offsetx + (int)availableCharacters[i].CharacterClass * multiplier, offsety + (int)availableCharacters[i].Allegiance * vertMult, pos.position.z); 
            CharButtons but = CharEmpires[(int)availableCharacters[i].Allegiance,(int)availableCharacters[i].CharacterClass].GetComponent<CharButtons>();
            but.LoadIcon(availableCharacters[i].CompName, availableCharacters[i].CharIcon); 
            CharEmpires[(int)availableCharacters[i].Allegiance,(int)availableCharacters[i].CharacterClass].transform.SetParent(this.transform, true); 
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
