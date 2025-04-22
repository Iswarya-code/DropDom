using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableBlock : MonoBehaviour
{
    Vector3 offset;
    bool isDraggable = false;

    private void OnMouseDown()
    {        
        // Capture mouse offset
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
        isDraggable = true;
    }

    private void OnMouseDrag()
    {
        if(!isDraggable)
        {
            return;
        }

        Vector3 mouseworldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseworldPos.x, mouseworldPos.y, 0) + offset;
    }

    private void OnMouseUp()
    {
        isDraggable = false;

        //Snap to nearest grid cell
        float snapX = Mathf.Round(transform.position.x);
        float snapY = Mathf.Round(transform.position.y);
        transform.position = new Vector3(snapX, snapY, 0);
    }
}
