using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private bool isEmpty = true;
    public bool getIsEmpty()
    {
        return isEmpty;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isEmpty)
        {
            GameObject item = eventData.pointerDrag;
            if (item != null)
            {
                isEmpty = false;
                item.GetComponent<DragDrop>().isPlacedFunc();
                item.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                sendAnswer(item);
            }
        }
    }

    private void sendAnswer(GameObject item)
    {
        int answer = int.Parse(item.name.Substring(2));
        GameObject.Find("Bridge").GetComponent<Bridge>().receiveAnswer(answer);
    }

    public void startHover()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1f);
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.3f);
    }

    public void endHover()
    {
        GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.19f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startHover();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        endHover();
    }

    public void setEmpty()
    {
        isEmpty = true;
    }
}
