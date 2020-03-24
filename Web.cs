using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
   void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest());

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/getdate.php"))
        {
            // Request and wait for the desired page.
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                
                byte[] results = www.downloadHandler.data;
            }
        }
    }
}