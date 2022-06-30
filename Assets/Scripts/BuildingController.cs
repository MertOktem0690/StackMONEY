using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingController : MonoBehaviour
{
    public Transform moneyGenerationPoint;
    public Transform moneyHolder;

    public TextMeshProUGUI buildScoreText;

    public GameObject money;

    Vector3 oldPositions;

    public int moneyCount, xAxis, yAxis, zAxis;
    public int givenMoney, buildValue;

    public bool xBool, yBool, zBool, isMoneyCollected, isItBuy;

    private bool isHolderFull;

    void Start()
    {
        givenMoney = 0;
        oldPositions = moneyGenerationPoint.position;
    }

    void Update()
    {
        buildScoreText.text = givenMoney.ToString() + "/" + buildValue;

        if (givenMoney==buildValue)
        {
            isItBuy = true;
        }

        if (isItBuy)
        {
            if (moneyCount == 0)
            {
                moneyGenerationPoint.position = oldPositions;
                isHolderFull = false;
                StartCoroutine(MoneyInterval());
            }
        }
    }

    IEnumerator MoneyInterval()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        if (moneyCount<60)
        {
            //z eksenin oluþturulacak paralar
            for (zAxis = 0; zAxis < 3; zAxis++)
            {
                //x eksenin oluþturulacak paralar
                for (xAxis = 0; xAxis < 4; xAxis++)
                {
                    //y eksenin oluþturulacak paralar
                    for (yAxis = 0; yAxis < 5; yAxis++)
                    {   
                        //paralarý moneyHolder'ýn içine atýyor
                        GameObject mon = Instantiate(money, moneyGenerationPoint);
                        mon.transform.SetParent(moneyHolder); 

                        yBool = true;

                        if (yBool)
                        {
                            //binalarýn önündeki paralarýn arasýndaki boþluklarý ve düzeni " Y EKSENÝNDE " saðlýyor
                            moneyGenerationPoint.position = new Vector3(moneyGenerationPoint.position.x,
                                                                        moneyGenerationPoint.position.y + 2f,
                                                                        moneyGenerationPoint.position.z);
                            yBool = false;
                        }

                        moneyCount++;

                        yield return wait;
                    }

                    xBool = true;
                    if (xBool)
                    {
                        //binalarýn önündeki paralarýn arasýndaki boþluklarý ve düzeni " X EKSENÝNDE " saðlýyor
                        moneyGenerationPoint.position = new Vector3(moneyGenerationPoint.position.x + 10f,
                                                                    oldPositions.y,
                                                                    moneyGenerationPoint.position.z);
                        xBool = false;
                    }
                }

                zBool = true;
                if (zBool)
                {
                    //binalarýn önündeki paralarýn arasýndaki boþluklarý ve düzeni " Z EKSENÝNDE " saðlýyor
                    moneyGenerationPoint.position = new Vector3(oldPositions.x,
                                                                oldPositions.y,
                                                                moneyGenerationPoint.position.z + 5f);
                    zBool = false;
                }
                // !!Dikkat!! z ekseninde oluþturulacak para miktarýnýn -1 i kadar yazýlmalý
                if (zAxis == 2)
                {
                    isHolderFull = true;
                }
            }
        }
    }
}