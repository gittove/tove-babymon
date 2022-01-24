using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NeedGenerator
{
    private BabyNeeds[] _objectArr;
    private BabyNeeds[] _wellbeingArr;
    private BabyNeeds[] _loveArr;

    private List<BabyNeeds> _openObjectList;
    private List<BabyNeeds> _openLoveList;
    private List<BabyNeeds> _openWellbeingList;
    private List<BabyNeeds> _closedList;

    public NeedGenerator()
    {
        _openObjectList = new List<BabyNeeds>();
        _openLoveList = new List<BabyNeeds>();
        _openWellbeingList = new List<BabyNeeds>();
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

    // TODO is this method neccessary?
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

        if (_objectArr.Contains(returnItem))
        {
            _openObjectList.Add(returnItem);
            Shuffle(_openObjectList);
        }

        else if (_loveArr.Contains(returnItem))
        {
            _openLoveList.Add(returnItem);
            Shuffle(_openLoveList);
        }

        else if (_wellbeingArr.Contains(returnItem))
        {
            _openWellbeingList.Add(returnItem);
            Shuffle(_openWellbeingList);
        }
    }

    public void SetUpLists()
    {
        _openObjectList = SetHungerList(_openObjectList);
        _openObjectList = Shuffle(_openObjectList);

        _openLoveList = SetLoveList(_openLoveList);
        _openLoveList = Shuffle(_openLoveList);

        _openWellbeingList = SetComfortList(_openWellbeingList);
        _openWellbeingList = Shuffle(_openWellbeingList);
    }

    public List<BabyNeeds> SetHungerList(List<BabyNeeds> inList)
    {
        _objectArr = new BabyNeeds[1] {BabyNeeds.Food};

        for (int i = 0; i < _objectArr.Length; i++)
        {
            inList.Add(_objectArr[i]);
        }

        return inList;
    }

    public List<BabyNeeds> SetLoveList(List<BabyNeeds> inList)
    {
        _loveArr = new BabyNeeds[1] {BabyNeeds.Toy};

        for (int i = 0; i < _loveArr.Length; i++)
        {
            inList.Add(_loveArr[i]);
        }

        return inList;
    }

    public List<BabyNeeds> SetComfortList(List<BabyNeeds> inList)
    {
        _wellbeingArr = new BabyNeeds[1] {BabyNeeds.Nap};

        for (int i = 0; i < _wellbeingArr.Length; i++)
        {
            inList.Add(_wellbeingArr[i]);
        }

        return inList;
    }
}