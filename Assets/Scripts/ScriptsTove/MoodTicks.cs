using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Moodticks SO", menuName = "ScriptableObjects/MoodTicks")]
public class MoodTicks : ScriptableObject
{
    public int[] objectTicks;
    public int[] wellbeingTicks;
    public int[] loveTicks;
}
