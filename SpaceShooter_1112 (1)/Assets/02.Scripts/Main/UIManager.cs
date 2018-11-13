using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnClickStartBtn( )
    {
        //Debug.Log("Click START Button : " + msg);
        SceneManager.LoadScene("Level1"); // 해당 씬 로드
        SceneManager.LoadScene("scPlay", LoadSceneMode.Additive); // Level1 로드 후 scPlay 추가
    }
}
