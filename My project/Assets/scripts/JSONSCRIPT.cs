using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class JSONSCRIPT : MonoBehaviour
{
    public Text nm;
    public Text lvl;
    public Text dat1;
    public Slider datchik;
    public string jsonURL;
    public JsonClass jsnData;
    // Start is called before the first frame update
    void Start()
    {
        datchik.interactable = (false);
        StartCoroutine(getdata());
    }
    IEnumerator getdata()
    {
        Debug.Log("Загрузка...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultfile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultfile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
        {
            nm.text = "Ошибка!";
        }
        else
        {
            Debug.Log("Файл сохранен по пути: " + resultfile);
            jsnData = JsonUtility.FromJson<JsonClass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            nm.text = jsnData.Name.ToString();
            lvl.text = jsnData.Level.ToString();
            dat1.text = jsnData.TestParam.ToString();
            datchik.value = jsnData.TestParam;
            yield return StartCoroutine(getdata());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class JsonClass
    {
        public string Name;
        public string Level;
        public int TestParam;
    }
}
