using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoneyCollector"))
        {
            //skor sayma
            PlayerController.instance.playerScore++;

            if (PlayerController.instance.bag.transform.childCount < 30)
            {
                //sýrtýmýza alýnan parayý burada çaðýrýyoruz
                PlayerController.instance.MoneytoBag();
            }
               
            //yerdeki paralarýn kaybolmasý
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            StartCoroutine(RegenerateMoney());
        }
    }

    //yerdeki paralarýn tekrar oluþmasý
    IEnumerator RegenerateMoney()
    {
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }
}