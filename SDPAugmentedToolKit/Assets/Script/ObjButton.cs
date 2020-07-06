using Dummiesman;
using System.IO;
using System.Text;
using UnityEngine;

public class ObjButton : MonoBehaviour
{

    // small obj url = https://drive.google.com/uc?export=download&id=1oH44E6wXVCUaJcg1FA7k_OuAsqJ59Thk


    string objPath = string.Empty;
    string error = string.Empty;
    GameObject loadedObject;

    void OnGUI()
    {
        objPath = GUI.TextField(new Rect(0, 0, 512, 64), objPath);

        GUI.Label(new Rect(0, 0, 512, 64), "Obj Path:");
        if (GUI.Button(new Rect(512, 64, 128, 64), "Load File"))
        {
            print(objPath);
            //make www
            WWW www = new WWW(objPath);



            while (!www.isDone)
                System.Threading.Thread.Sleep(1);

            //create stream and load
            var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.text));
            var loadedObj = new OBJLoader().Load(textStream);

        }

    }
}
