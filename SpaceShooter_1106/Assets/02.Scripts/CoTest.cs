using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoTest : MonoBehaviour
{
    public bool chk = true;

    void Start()
    {
        StartCoroutine(CoStopTest());
    }

    IEnumerator CoStopTest()
    {
        while (chk)
        {
            Debug.Log("01");
            Debug.Log("02");
            Debug.Log("03");
            Debug.Log("04");
            Debug.Log("05");
            Debug.Log("06");
            Debug.Log("07");
            Debug.Log("08");
            Debug.Log("09");
            Debug.Log("10");
            Debug.Log("11");
            Debug.Log("12");
            Debug.Log("13");
            Debug.Log("14");
            Debug.Log("15");
            Debug.Log("16");
            Debug.Log("17");
            Debug.Log("18");
            Debug.Log("19");
            Debug.Log("20");
            Debug.Log("21");
            Debug.Log("22");
            Debug.Log("23");
            Debug.Log("24");
            Debug.Log("25");
            Debug.Log("26");
            Debug.Log("27");
            Debug.Log("28");
            Debug.Log("29");
            Debug.Log("30");
            Debug.Log("31");
            Debug.Log("32");
            Debug.Log("33");
            Debug.Log("34");
            Debug.Log("35");
            Debug.Log("36");
            Debug.Log("37");
            Debug.Log("38");
            Debug.Log("39");
            Debug.Log("40");
            Debug.Log("41");
            Debug.Log("42");
            Debug.Log("43");
            Debug.Log("44");
            Debug.Log("45");
            Debug.Log("46");
            Debug.Log("47");
            Debug.Log("48");
            Debug.Log("49");
            Debug.Log("50");
            Debug.Log("51");
            Debug.Log("52");
            Debug.Log("53");
            Debug.Log("54");
            Debug.Log("55");
            Debug.Log("56");
            Debug.Log("57");
            Debug.Log("58");
            Debug.Log("59");
            Debug.Log("60");
            Debug.Log("61");
            Debug.Log("62");
            Debug.Log("63");
            Debug.Log("64");
            Debug.Log("65");
            Debug.Log("66");
            Debug.Log("67");
            Debug.Log("68");
            Debug.Log("69");
            Debug.Log("70");
            Debug.Log("71");
            Debug.Log("72");
            Debug.Log("73");
            Debug.Log("74");
            Debug.Log("75");
            Debug.Log("76");
            Debug.Log("77");
            yield return null;
            Debug.Log("78");
            Debug.Log("79");
            Debug.Log("80");
            Debug.Log("81");
            Debug.Log("82");
            Debug.Log("83");
            Debug.Log("84");
            Debug.Log("85");
            Debug.Log("86");
            Debug.Log("87");
            Debug.Log("88");
            Debug.Log("89");
            Debug.Log("90");
            Debug.Log("91");
            Debug.Log("92");
            Debug.Log("93");
            Debug.Log("94");
            Debug.Log("95");
            Debug.Log("96");
            Debug.Log("97");
            Debug.Log("98");
            Debug.Log("99");
            Debug.Log("00");
            //yield return null;
        }
        
    }

    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            StopCoroutine(CoStopTest());
            chk = false;
            Debug.Log("Coroutine Stop!!!");
        }
    }
}
