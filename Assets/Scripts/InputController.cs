using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject PlayerUIPanel;
    void Update()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D rayHit = Physics2D.Raycast(CurMousePos, Vector2.zero);
            if (rayHit.transform != null)
            {
                if (rayHit.transform.tag == "PlayerCastle")
                {
                    PlayerUIPanel.SetActive(true);
                }
                else
                {
                    
                }
            }
        }
    }
}
