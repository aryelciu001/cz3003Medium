using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private Vector2 stopVelo = new Vector2(0, 0);
    private Vector2 curVelo;
    private Vector2 curPos;
    private bool isPlaced = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rigidBody = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced)
        {
            GameObject.Find("AnswerPlace").GetComponent<DropPlace>().setEmpty();
            isPlaced = false;
        }
        else
        {
            curPos = rectTransform.position;
            curVelo = rigidBody.velocity;
        }
        pause();   
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        replay();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    private void pause()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        boxCollider.enabled = false;
        rigidBody.velocity = stopVelo;
    }
    private void replay()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (!isPlaced)
        {
            boxCollider.enabled = true;
            rigidBody.velocity = curVelo;
            rectTransform.position = curPos;
        }
    }

    public void isPlacedFunc()
    {
        isPlaced = true;
    }
}
