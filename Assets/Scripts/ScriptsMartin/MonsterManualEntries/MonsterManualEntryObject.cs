using UnityEngine;

[CreateAssetMenu(menuName = "Monster Manual/New Entry", fileName = "New MonsterManual Entry")]
public class MonsterManualEntryObject : ScriptableObject
{

    public string babyName;
    public Sprite babySprite;
    [TextArea(2, 6)]public string babyDescription;

    public string babyLikes;
    public string babyDislikes;

    public string parentName;
    public Sprite parentSprite;
    [TextArea(2, 6)] public string parentDescription;

}
