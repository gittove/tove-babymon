using UnityEngine;

public class MonsterManualClose : MonoBehaviour
{
    [SerializeField] private ManualOpen _manual;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameObject.SetActive(false);
            _manual.Resume();
        }
    }
}
