using UnityEngine;
using UnityEngine.EventSystems;

[AddComponentMenu("Audio/UI Animation Trigger")]
public class UIAnimationTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private RectTransform rect;
    [SerializeField] private Vector2 sizeIdle, sizeHover;
    [SerializeField] private AnimationCurve animateIn, animateOut, animateClick;
    [SerializeField] private float time = 0.1f;

    [Space]
    public bool animateTransform = false;
    [SerializeField] private Vector3 transformSizeIdle = new Vector3(1,1,1), transformSizeHover = new Vector3(1.2f, 1.2f, 1.2f);

    private void Awake()
    {
        if(GetComponent<RectTransform>()) rect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData) => AnimateEnter();
    public void OnPointerExit(PointerEventData eventData) => AnimateExit();
    public void OnPointerClick(PointerEventData eventData) => AnimateClick();
    private void OnMouseEnter() => AnimateEnter();
    private void OnMouseExit() => AnimateExit();
    public void OnMouseUpAsButton() => AnimateClick();

    public void AnimateEnter()
    {
        if(rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeIdle, sizeHover, animateIn);
        }
        else if (animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeIdle, transformSizeHover, animateIn);
        }
    }

    public void AnimateExit()
    {
        if (rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeHover, sizeIdle, animateOut);
        }
        else if(animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeHover, transformSizeIdle, animateOut);
        }
    }

    public void AnimateClick()
    {
        if (rect != null)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(rect, sizeHover, sizeIdle, animateClick);
        }
        else if (animateTransform)
        {
            mTween.CancelTween(this);
            mTween.NewTween(this, time).ScaleTo(transform, transformSizeHover, transformSizeIdle, animateClick);
        }
    }
}