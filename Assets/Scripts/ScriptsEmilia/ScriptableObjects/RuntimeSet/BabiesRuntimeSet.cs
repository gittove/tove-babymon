using UnityEngine;
[CreateAssetMenu(fileName = "new Runtime Set Baby Profile", menuName = "ScriptableObjects/RuntimeSets/Baby Profile", order = 0)]
public class BabiesRuntimeSet : RuntimeSetBase<BabyProfile>
{
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
