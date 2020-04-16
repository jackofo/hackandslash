using UnityEngine;
using System.Collections;

[System.Serializable]
public class Experience
{
	[SerializeField]
    int level = 0;
    int experience = 0;
    int expRequired = 10;
    
 
    public void GainExp(int e)
    {
		experience += e;
		while(experience>expRequired)
		{
			LvlUp();
			expRequired += expRequired + (int)(expRequired * 0.1);
		}
    }
    void LvlUp()
    {
		level++;
    }
}