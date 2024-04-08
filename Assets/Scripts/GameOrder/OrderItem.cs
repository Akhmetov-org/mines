using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItem : MonoBehaviour
{
    public int typeElement;
    public bool isIncognito;
    public Button butItem;
    public Image childrenMines;
    public Image childrenMask;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void getType(int value)
    {
        typeElement = value + 1;
        childrenMines.sprite = StaticConfig.SweetsCastlePlayList[typeElement];
    }
    public void clickElemOrder()
    {
        if (!isIncognito)
        {
            StaticConfig.currentOrderItem = this;
            butItem.image.sprite = StaticConfig.stateCastlePlayList[0];
        }
        else
        {
            if (typeElement != 0 && typeElement == StaticConfig.currentOrderItem.typeElement)
            {
                StaticConfig.currentOrderItem.childrenMines.enabled = false;
                StaticConfig.currentOrderItem.butItem.interactable = false;
                StaticConfig.currentOrderItem.butItem.image.enabled = false;

                childrenMask.enabled = false;
                childrenMines.enabled = true;
                butItem.image.sprite = StaticConfig.stateCastlePlayList[0];


                StaticConfig.currentOrderItem = null;
                StaticConfig.valueIncognitoElem--;
                if (StaticConfig.valueIncognitoElem == 0) 
                {
                    ControllReserses.youWinOrdern();
                }
                print("!!!");
            }
            else
            {
                print("game over");
                ControllReserses.youLostOrdern();
            }
        }


    }
}
