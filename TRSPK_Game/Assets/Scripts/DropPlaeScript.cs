using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlaeScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    
    
    public void OnDrop(PointerEventData eventData)
    {
        CardScr card = eventData.pointerDrag.GetComponent<CardScr>();
        SlotScript slot = GetComponent<SlotScript>();
        money m = GameObject.Find("Money").GetComponent<money>();
        

        if (card && !slot.isBusy && m.isEnough)
        {
            card.DefaultParent = transform;
            card.isDropped = true;

            Spawner spawn = eventData.pointerDrag.GetComponent<Spawner>();
            spawn.Spawn();
            card.transform.position = card.DefaultParent.position;
            Debug.Log("called from DropPlaceScript");
        }
        
        
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (eventData == null)
        {
            return;
        }

        var pointerDrag = eventData.pointerDrag;
        if (!pointerDrag)
        {
            return;
        }
        

        var card = pointerDrag.GetComponent<CardScr>();
        if (card)
        {
            card.DefaultTmpCardParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData == null)
        {
            return;
        }

        var pointerDrag = eventData.pointerDrag;
        if (!pointerDrag)
        {
            return;
        }

        var card = pointerDrag.GetComponent<CardScr>();
        if (card && card.DefaultTmpCardParent == transform)
        {
            card.DefaultTmpCardParent = card.DefaultParent;
        }
    }
}
