using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ChangeNeedSprites : MonoBehaviour
{
    // [Header("References")]
    // [SerializeField] 
    // private BabyController babyController;

    [SerializeField] 
    private Image wellbeing;
    [SerializeField] 
    private Image objectImage;
    [SerializeField] 
    private Image love;

    public Sprite Wellbeing
    {
        get { return wellbeing.sprite;}
        set
        {
            wellbeing.sprite = value;
        }
    }
    
    public Sprite ObjectImage
    {
        get { return objectImage.sprite;}
        set
        {
            objectImage.sprite = value;
            
        }
    }
    
    public Sprite Love
    {
        get { return love.sprite;}
        set
        {
            love.sprite = value;
        }
    }

}
