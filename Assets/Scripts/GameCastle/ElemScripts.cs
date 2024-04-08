using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElemScripts : MonoBehaviour
{
    public Image childrenImage; 
    [SerializeField] public Vector2Int nomberElem;
    [SerializeField] public int type;
    [SerializeField] private Button currentButton;
    [SerializeField] public Image currentButtonImage;
    [SerializeField] public Text currentPercent;


    public void Start()
    {
        currentButton = this.gameObject.GetComponent<Button>();
        currentButtonImage = currentButton.image;
    }

    public void getType(int value)
    {
        type = value;
    }
    public void interectble(bool isActive)
    {
        currentButton.interactable = isActive;
    }
    public void clickElem()
    {
        print(nomberElem);
        childrenImage.enabled = true;
        currentPercent.enabled = false;
        if (type == 0)
        {
            childrenImage.sprite = StaticConfig.SweetsCastlePlayList[0];
            ControllCastlePlay.choiseSworm(this);
            print("game over");
        }
        else
        {
            print("��������� ������");
            
            childrenImage.sprite = StaticConfig.SweetsCastlePlayList[Random.Range(1, 13)];
            StaticConfig.currentActiveStringCastlePlay++;
            ControllCastlePlay.clouseString(this);
        }
    }

}
