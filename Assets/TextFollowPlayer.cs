using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollowPlayer : MonoBehaviour
{
    public GameObject Player;
    void Update() => textUIFollowObject();

    private void textUIFollowObject()
    {
        Vector2 textPosition = Camera.main.WorldToScreenPoint(Player.transform.position);
        transform.position = textPosition;
    }
}
