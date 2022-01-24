using UnityEngine;

[CreateAssetMenu(fileName = "new Moodticks SO", menuName = "ScriptableObjects/MoodTicks")]
public class MoodTicks : ScriptableObject
{
    // TODO add headers and tooltips
    public int[] objectTicks;
    public int[] wellbeingTicks;
    public int[] loveTicks;
}
