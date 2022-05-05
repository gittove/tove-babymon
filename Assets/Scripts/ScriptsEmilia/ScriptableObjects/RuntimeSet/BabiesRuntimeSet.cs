using UnityEngine;
[CreateAssetMenu(fileName = "new Runtime Set Baby Profile", menuName = "ScriptableObjects/RuntimeSets/Baby Profile", order = 0)]
public class BabiesRuntimeSet : RuntimeSetBase<BabyProfile>
{
    private static int _globalActiveNeedsCount;

    public delegate void OnValueChanged(int value);

    public static event OnValueChanged onValueChanged;

    public static void RaiseActiveNeedsCountChanged(int addvalue)
    {
        if (onValueChanged != null)
        {
            _globalActiveNeedsCount += addvalue;
            Debug.Log(_globalActiveNeedsCount);
            onValueChanged.Invoke(_globalActiveNeedsCount);
        }
    }

    public float GetTotalScore()
    {
        float totalScore = 0;

        for (int i = 0; i < setList.Count; i++)
        {
            totalScore += setList[i].babyHappiness;
        }
        return totalScore;
    }
    
    
}
