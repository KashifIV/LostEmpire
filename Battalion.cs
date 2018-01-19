using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battalion : MonoBehaviour {

    public string commander, Name;
    private int charIndex;
    public Characters ComChar; 
    private List<Characters> availableCharacters; 
	// Use this for initialization
	void Start () {
		
	}
    public void InitiateCommand(List<Characters> thisLoadChars)
    {
        availableCharacters = thisLoadChars;
        for (int i = 0; i < availableCharacters.Count; i++)
        {
            if (availableCharacters[i].CompName == commander)
            {
                ComChar = availableCharacters[i];
                charIndex = i; 
            }
        }
    }
    public void LoadCommand()
    {
        ComChar.FadeBannerIn(); 
    }
    public void DeLoadCommand()
    {
        availableCharacters[charIndex].FadeBannerOut(); 
    }
    public void LoadNextCommand(bool isRight)
    {
        int tempI;
        if (isRight)
            tempI = charIndex - 1;
        else
            tempI = charIndex + 1;
        if (tempI < 0)
            tempI = availableCharacters.Count - 1;
        else if (tempI == availableCharacters.Count)
            tempI = 0;
        foreach (GameObject banners in GameObject.FindGameObjectsWithTag("Banner"))
        {
            if (banners.name == (ComChar.CompName + "Banner(Clone)"))
            {
                ComChar.StopAllCoroutines();
                Destroy(banners);
                break; 
            }
        }
        availableCharacters[charIndex].StopAllCoroutines(); 
        availableCharacters[charIndex].FadeBannerOut();
        if (isRight)
            charIndex++;
        else
            charIndex--;
        if (charIndex == availableCharacters.Count)
            charIndex = 0;
        else if (charIndex < 0)
            charIndex = availableCharacters.Count - 1; 
        availableCharacters[charIndex].StopAllCoroutines(); 
        availableCharacters[charIndex].FadeBannerIn(); 
        ComChar = availableCharacters[charIndex]; 
    }
	// Update is called once per frame
	void Update () {
		
	}
    public int CharIndex
    {
        get
        {
            return charIndex; 
        }
    }
        
}
