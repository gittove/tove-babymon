using UnityEngine.Events;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu("mEvents/mEvents")]
public class mEvents : MonoBehaviour
{
    public bool canTrigger = true;

    [Serializable] public enum mKeyPress { Down, Up, Hold }
    [Serializable] public struct Combination
    {
        public mKeyPress Keypress;
        public KeyCode key;
        public Combination(KeyCode key)
        {
            Keypress = mKeyPress.Down;
            this.key = key;
        }
    }
    [Serializable] public class mInputType
    {
        public bool expanded;
        public int inSettings;
        public string ID;
        public bool canTrigger;
        public Combination[] Combination;
        public UnityEvent inputEvent;
        public int selectedAction;

        public int localOrGlobal;

        public int currentEventType = 0;
        public GameEvent gameEvent;
        public GameEventFloat gameEventFloat;
        public float gameEventFloatValue;
        public GameEventInt gameEventInt;
        public int gameEventIntValue;
        public GameEventBool gameEventBool;
        public bool gameEventBoolValue;
        public GameEventChar gameEventChar;
        public char gameEventCharValue;
        public GameEventString gameEventString;
        public string gameEventStringValue;
        public GameEventVector2 gameEventVector2;
        public Vector2 gameEventVector2Value;
        public GameEventVector3 gameEventVector3;
        public Vector3 gameEventVector3Value;
        public GameEventColor gameEventColor;
        public Color gameEventColorValue;
        public GameEventObject gameEventObject;
        public object gameEventObjectValue;

        public mInputType()
        {
            this.canTrigger = true;
            this.expanded = true;
            this.ID = "New Event";
        }
    }

    [SerializeField, HideInInspector] public List<mInputType> inputEvents = new List<mInputType>();
    public void AddNewEvent() => inputEvents.Add(new mInputType());

    [SerializeField, HideInInspector] public LayerMask layerMask;
    [SerializeField, HideInInspector] public LayerMask layerMask2D;

    [SerializeField, HideInInspector] public List<mMonoType> monoEvents = new List<mMonoType>();
    [SerializeField, HideInInspector] public string[] monoEventsDisplay;

    [SerializeField, HideInInspector] public int currentTab;
    [SerializeField, HideInInspector] public int MonoBehaviour;

    [SerializeField, HideInInspector] public mTriggerType triggerType;
    [SerializeField, HideInInspector] public mTriggerType triggerType2D;

    public void SetCanTrigger(bool state) => canTrigger = state;

    private void Awake()
    {
        if (monoEvents.Count <= 0)
        {
            layerMask = LayerMask.NameToLayer("Default");
            layerMask2D = LayerMask.NameToLayer("Default");
            monoEvents = new List<mMonoType>
        {
            new mMonoType(false, false, "onAwake"),
            new mMonoType(false, false, "onStart"),
            new mMonoType(false, false, "onUpdate"),
            new mMonoType(false, false, "onLateUpdate"),
            new mMonoType(false, false, "onFixedUpdate"),
            new mMonoType(false, false, "onEnable"),
            new mMonoType(false, false, "onDisable"),
            new mMonoType(false, false, "onDestroy"),
            new mMonoType(false, false, "onTriggerEnter"),
            new mMonoType(false, false, "onTriggerStay"),
            new mMonoType(false, false, "onTriggerExit"),
            new mMonoType(false, false, "onTriggerEnter2D"),
            new mMonoType(false, false, "onTriggerStay2D"),
            new mMonoType(false, false, "onTriggerExit2D"),
            new mMonoType(false, false, "onCollisionEnter"),
            new mMonoType(false, false, "onCollisionStay"),
            new mMonoType(false, false, "onCollisionExit"),
            new mMonoType(false, false, "onCollisionEnter2D"),
            new mMonoType(false, false, "onCollisionStay2D"),
            new mMonoType(false, false, "onCollisionExit2D"),
            new mMonoType(false, false, "onMouseEnter"),
            new mMonoType(false, false, "onMouseOver"),
            new mMonoType(false, false, "onMouseExit"),
            new mMonoType(false, false, "onMouseDown"),
            new mMonoType(false, false, "onMouseUp"),
            new mMonoType(false, false, "onMouseUpAsButton"),
        };
        }

        if (!canTrigger || !monoEvents[0].Visible) return;
        monoEvents[0].unityEvent?.Invoke();
    }
    private void Start()
    {
        if (!canTrigger || !monoEvents[1].Visible) return;
        monoEvents[1].unityEvent?.Invoke();
    }

    private void Update()
    {
        if (!canTrigger) return;

        for (int i = 0; i < inputEvents.Count; i++)
        {
            if (!inputEvents[i].canTrigger)
                continue;

            if (GetKey(i))
            {
                TryTriggerEvent(i);
            }
        }

        if (!monoEvents[2].Visible) return;

        monoEvents[2].unityEvent?.Invoke();
    }

    public void TriggerEvent(string ID)
    {
        for (int i = 0; i < inputEvents.Count; i++)
        {
            if (inputEvents[i].ID == ID)
                TryTriggerEvent(i);
        }
    }
    private void TryTriggerEvent(int i)
    {
        inputEvents[i].inputEvent?.Invoke();

        if (inputEvents[i].gameEvent != null)
            inputEvents[i].gameEvent.TriggerEvent();

        if (inputEvents[i].gameEventFloat != null)
            inputEvents[i].gameEventFloat.TriggerEvent(inputEvents[i].gameEventFloatValue);

        if (inputEvents[i].gameEventInt != null)
            inputEvents[i].gameEventInt.TriggerEvent(inputEvents[i].gameEventIntValue);

        if (inputEvents[i].gameEventBool != null)
            inputEvents[i].gameEventBool.TriggerEvent(inputEvents[i].gameEventBoolValue);

        if (inputEvents[i].gameEventChar != null)
            inputEvents[i].gameEventChar.TriggerEvent(inputEvents[i].gameEventCharValue);

        if (inputEvents[i].gameEventString != null)
            inputEvents[i].gameEventString.TriggerEvent(inputEvents[i].gameEventStringValue);

        if (inputEvents[i].gameEventVector2 != null)
            inputEvents[i].gameEventVector2.TriggerEvent(inputEvents[i].gameEventVector2Value);

        if (inputEvents[i].gameEventVector3 != null)
            inputEvents[i].gameEventVector3.TriggerEvent(inputEvents[i].gameEventVector3Value);

        if (inputEvents[i].gameEventColor != null)
            inputEvents[i].gameEventColor.TriggerEvent(inputEvents[i].gameEventColorValue);

        if (inputEvents[i].gameEventObject != null)
            inputEvents[i].gameEventObject.TriggerEvent(inputEvents[i].gameEventObjectValue);
    }

    private bool GetKey(int i)
    {
        bool[] keys = new bool[inputEvents[i].Combination.Length];

        for (int x = 0; x < inputEvents[i].Combination.Length; x++)
        {
            switch (inputEvents[i].Combination[x].Keypress)
            {
                case mKeyPress.Down:
                    keys[x] = Input.GetKeyDown(inputEvents[i].Combination[x].key);

                    if (keys[x] == false)
                        return false;

                    continue;

                case mKeyPress.Up:
                    keys[x] = Input.GetKeyUp(inputEvents[i].Combination[x].key);

                    if (keys[x] == false)
                        return false;

                    continue;

                case mKeyPress.Hold:
                    keys[x] = Input.GetKey(inputEvents[i].Combination[x].key);

                    if (keys[x] == false)
                        return false;

                    continue;
            }
        }

        return keys.Any(x => true);
    }

    private void LateUpdate()
    {
        if (!canTrigger || !monoEvents[3].Visible) return;
        monoEvents[3].unityEvent?.Invoke();
    }
    private void FixedUpdate()
    {
        if (!canTrigger || !monoEvents[4].Visible) return;
        monoEvents[4].unityEvent?.Invoke();
    }

    private void OnEnable()
    {
        if (!canTrigger || !monoEvents[5].Visible) return;
        monoEvents[5].unityEvent?.Invoke();
    }
    private void OnDisable()
    {
        if (!canTrigger || !monoEvents[6].Visible) return;
        monoEvents[6].unityEvent?.Invoke();
    }
    private void OnDestroy()
    {
        if (!canTrigger || !monoEvents[7].Visible) return;
        monoEvents[7].unityEvent?.Invoke();
    }
    private void OnTriggerEnter(Collider col)
    {
        if (!canTrigger || !monoEvents[8].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask) != 0)
            monoEvents[8].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnTriggerStay(Collider col)
    {
        if (!canTrigger || !monoEvents[9].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask) != 0)
            monoEvents[9].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnTriggerExit(Collider col)
    {
        if (!canTrigger || !monoEvents[10].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask) != 0)
            monoEvents[10].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!canTrigger || !monoEvents[11].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[11].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (!canTrigger || !monoEvents[12].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask) != 0)
            monoEvents[12].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (!canTrigger || !monoEvents[13].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[13].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!canTrigger || !monoEvents[14].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[14].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnCollisionStay(Collision col)
    {
        if (!canTrigger || !monoEvents[15].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[15].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnCollisionExit(Collision col)
    {
        if (!canTrigger || !monoEvents[16].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[16].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!canTrigger || !monoEvents[17].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[17].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (!canTrigger || !monoEvents[18].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[18].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (!canTrigger || !monoEvents[19].Visible) return;

        if (((1 << col.gameObject.layer) & layerMask2D) != 0)
            monoEvents[19].unityEvent?.Invoke();

        Trigger(col.gameObject, triggerType);
    }

    private void Trigger(GameObject col, mTriggerType i)
    {
        if (i.SendMessage)
        {
            switch (i.messageType)
            {
                case mTriggerTypeEnum.None:
                    col.SendMessage(i.Message);
                    break;
                case mTriggerTypeEnum.Float:
                    col.SendMessage(i.Message, triggerType2D.messageInfoFloat, SendMessageOptions.DontRequireReceiver);
                    break;
                case mTriggerTypeEnum.Int:
                    col.SendMessage(i.Message, triggerType2D.messageInfoInt, SendMessageOptions.DontRequireReceiver);
                    break;
                case mTriggerTypeEnum.Bool:
                    col.SendMessage(i.Message, triggerType2D.messageInfoBool, SendMessageOptions.DontRequireReceiver);
                    break;
                case mTriggerTypeEnum.String:
                    col.SendMessage(i.Message, triggerType2D.messageInfoString, SendMessageOptions.DontRequireReceiver);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (!canTrigger || !monoEvents[20].Visible) return;
        monoEvents[20].unityEvent?.Invoke();
    }
    private void OnMouseOver()
    {
        if (!canTrigger || !monoEvents[21].Visible) return;
        monoEvents[21].unityEvent?.Invoke();
    }
    private void OnMouseExit()
    {
        if (!canTrigger || !monoEvents[22].Visible) return;
        monoEvents[22].unityEvent?.Invoke();
    }
    private void OnMouseDown()
    {
        if (!canTrigger || !monoEvents[23].Visible) return;
        monoEvents[23].unityEvent?.Invoke();
    }
    private void OnMouseUp()
    {
        if (!canTrigger || !monoEvents[24].Visible) return;
        monoEvents[24].unityEvent?.Invoke();
    }
    private void OnMouseUpAsButton()
    {
        if (!canTrigger || !monoEvents[25].Visible) return;
        monoEvents[25].unityEvent?.Invoke();
    }
}

[Serializable] public class mMonoType
{
    public bool Visible;
    public bool Expanded;
    public string ID;
    public UnityEvent unityEvent = new UnityEvent();
    public Action actionEvent;
    public mMonoType(bool visible, bool expanded, string ID)
    {
        Expanded = expanded;
        Visible = visible;
        this.ID = ID;
    }
}

[Serializable] public struct mTriggerType
{
    public bool performAction;

    public mTriggerTypeEnum messageType;

    public bool SendMessage;
    public string Message;
    public float messageInfoFloat;
    public int messageInfoInt;
    public bool messageInfoBool;
    public string messageInfoString;
}

public enum mTriggerTypeEnum
{
    None, Float, Int, Bool, String
}