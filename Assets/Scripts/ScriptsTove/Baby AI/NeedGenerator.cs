using System.Collections.Generic;
using UnityEngine;

public class NeedGenerator
{
    private List<BabyNeeds> _objectLookUp;
    private List<BabyNeeds> _wellbeingLookUp;
    private List<BabyNeeds> _loveLookUp;

    private List<BabyNeeds> _openObjectList;
    private List<BabyNeeds> _openLoveList;
    private List<BabyNeeds> _openWellbeingList;
    private List<BabyNeeds> _closedList;

    public NeedGenerator(BehaviorDictionary dictionary)
    {
        _openObjectList = dictionary.ObjectList;
        _openLoveList = dictionary.LoveList;
        _openWellbeingList = dictionary.WellbeingList;
        _closedList = new List<BabyNeeds>();

        SetUpLists();
    }

    private List<BabyNeeds> Shuffle(List<BabyNeeds> inList)
    {
        for (int i = 0; i < inList.Count - 1; i++)
        {
            BabyNeeds temp = inList[i];
            int rand = Random.Range(i, inList.Count);
            inList[i] = inList[rand];
            inList[rand] = temp;
        }

        return inList;
    }

    public bool IsItemInList(List<BabyNeeds> inList)
    {
        if (inList.Count > 0)
        {
            return true;
        }
        else if (inList.Count == 0)
        {
            return false;
        }

        return false;
    }

    public bool isObjectInList()
    {
        return IsItemInList(_openObjectList);
    }

    public bool IsWellbeingInList()
    {
        return IsItemInList(_openWellbeingList);
    }

    public bool isLoveInList()
    {
        return IsItemInList(_openLoveList);
    }

    public BabyNeeds GetObjectItem()
    {
        BabyNeeds item;

        item = _openObjectList[0];
        _openObjectList.RemoveAt(0);
        _closedList.Add(item);

        return item;
    }

    public BabyNeeds GetLoveItem()
    {
        BabyNeeds item;

        item = _openLoveList[0];
        _openLoveList.RemoveAt(0);
        _closedList.Add(item);

        return item;
    }

    public BabyNeeds GetWellbeingItem()
    {
        BabyNeeds item;

        item = _openWellbeingList[0];
        _openWellbeingList.RemoveAt(0);
        _closedList.Add(item);

        return item;
    }

    public void ReturnItem(BabyNeeds returnItem)
    {
        _closedList.Remove(returnItem);

        if (_objectLookUp.Contains(returnItem))
        {
            _openObjectList.Add(returnItem);
            Shuffle(_openObjectList);
        }

        else if (_loveLookUp.Contains(returnItem))
        {
            _openLoveList.Add(returnItem);
            Shuffle(_openLoveList);
        }

        else if (_wellbeingLookUp.Contains(returnItem))
        {
            _openWellbeingList.Add(returnItem);
            Shuffle(_openWellbeingList);
        }
    }

    public void SetUpLists()
    {
        _openObjectList.Remove(BabyNeeds.None);
        _objectLookUp = new List<BabyNeeds>(_openObjectList);
        _openObjectList = Shuffle(_openObjectList);

        _openLoveList.Remove(BabyNeeds.None);
        _loveLookUp = new List<BabyNeeds>(_openLoveList);
        _openLoveList = Shuffle(_openLoveList);

        _openWellbeingList.Remove(BabyNeeds.None);
        _wellbeingLookUp = new List<BabyNeeds>(_openWellbeingList);
        _openWellbeingList = Shuffle(_openWellbeingList);
    }
}