using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GridOrderScript : MonoBehaviour
{

    public GameObject imageWait;
    public Text textWaiting;
    public Button elemGrid;
    public GameObject gridIncognito;
    public GameObject gridYes;
    public GameObject Menu;
    public GameObject SetUpOrder;
    public Button currentElemGrid;
    public int[] orderIncognito;
    public int[] orderYes;



    [SerializeField] private OrderItem[] IncognitoList = new OrderItem[10];
    [SerializeField] private OrderItem[] yesList = new OrderItem[10];
    public void startGame(int valueString)
    {
        if (StaticConfig.coins - StaticConfig.currentStavka < 0)
        {
            StaticConfig.buyCoin.SetActive(true);
            return;
        }
        else if (StaticConfig.hearts - 1 < 0)
        {
            StaticConfig.buyHearth.SetActive(true);
            return;
        }

        ControllReserses.changeCoinsValue(-StaticConfig.currentStavka);
        ControllReserses.changeHeartsValue(-1);

        newOrderGame();
        StaticConfig.valueIncognitoElem = 6 * valueString;

        SetUpOrder.SetActive(false);
        Menu.SetActive(false);
        this.gameObject.SetActive(true);
        IncognitoList = new OrderItem[6 * valueString];
        yesList = new OrderItem[6 * valueString];
        orderIncognito = new int[6 * valueString];
        orderYes = new int[6 * valueString];
        if (valueString != 3)
        {
            for (int i = 0; i < 6 * valueString; i++)
            {
                orderIncognito[i] = i;
                orderYes[i] = i;
            }
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                orderIncognito[i] = i;
                orderYes[i] = i;
            }
            for (int i = 0; i < 6; i++)
            {
                orderIncognito[i + 12] = i + 6;
                orderYes[i + 12] = i + 6;
            }
        }
        shuffle(ref orderYes);
        shuffle(ref orderIncognito);




        for (int i = 0; i < 6 * valueString; i++)
        {
            currentElemGrid = Instantiate(elemGrid, gridIncognito.transform);
            IncognitoList[i] = currentElemGrid.GetComponent<OrderItem>();
            IncognitoList[i].isIncognito = true;
            IncognitoList[i].getType(orderIncognito[i]);
        }
        for (int i = 0; i < 6 * valueString; i++)
        {
            currentElemGrid = Instantiate(elemGrid, gridYes.transform);
            OrderItem currentOrderItem = currentElemGrid.GetComponent<OrderItem>();
            yesList[i] = currentOrderItem;
            currentOrderItem.isIncognito = false;
            currentOrderItem.getType(orderYes[i]);
            currentOrderItem.butItem.image.sprite = StaticConfig.stateCastlePlayList[0];
        }
        StartCoroutine(Waiting());
    }
    private IEnumerator Waiting()
    {
        imageWait.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            textWaiting.text = (10 - i).ToString();
            yield return new WaitForSeconds(1);
        }
        foreach (OrderItem item in IncognitoList)
        {
            item.childrenMask.enabled = true;
            item.childrenMines.enabled = false;
        }
        imageWait.SetActive(false);
    }
    public void newOrderGame()
    {
        //if (ControllReserses.changeHeartsValue(-1))
        //{
        StaticConfig.winWindowOrder.SetActive(false);
        //}
        while (gridIncognito.transform.childCount > 0)
        {
            DestroyImmediate(gridIncognito.transform.GetChild(0).gameObject);
        }
        while (gridYes.transform.childCount > 0)
        {
            DestroyImmediate(gridYes.transform.GetChild(0).gameObject);
        }
        IncognitoList = null;
        yesList = null;
        orderIncognito = null;
        orderYes = null;
    }
    public void shuffle(ref int[] array)
    {
        System.Random rnd = new System.Random();
        array = array.OrderBy(item => rnd.Next()).ToArray();
    }

}
