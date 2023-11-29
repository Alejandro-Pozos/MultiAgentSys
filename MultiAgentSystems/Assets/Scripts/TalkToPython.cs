using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TalkToPython : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TalkWithGET());
        StartCoroutine(TalkWithPOST());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TalkWithPOST()//
        {
            WWWForm theData = new WWWForm();
            theData.AddField("name","Moises");

            using (UnityWebRequest www = UnityWebRequest.Post
            ("http://127.0.0.1:8000/getPositions",theData))
            {
                yield return www.SendWebRequest();
                if(www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);

                }
                else{
                    Debug.Log("Server said:" + www.downloadHandler.text);
                }
            }
        }
}
