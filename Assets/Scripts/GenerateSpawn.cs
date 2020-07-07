using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSpawn : MonoBehaviour
{
    //public Text nameLabel;
    //public GameObject sph;
    public Canvas canvas;
    
    public GameObject pickUpPrefab;
    private int xPos;
    //private int yPos = 1;
    private int zPos;

    private int spawnCount;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropSpawn());
    }


    private static System.Random random = new System.Random();
    public static string RandomString()
    {
        int length = random.Next(9, 16);
        const string chars = "a2";
        string abc = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        //return new string(Enumerable.Repeat(chars, length)
        //  .Select(s => s[random.Next(s.Length)]).ToArray());
        return "x" + abc;
    }


    IEnumerator DropSpawn()
    {
        GameObject randomText = new GameObject("Collectible Text");
        while (spawnCount <= 9)
        {
            
            xPos = Random.Range(-23, 23);
            zPos = Random.Range(-31, 31);
            GameObject abc = Instantiate(pickUpPrefab, new Vector3(xPos, 1, zPos), Quaternion.identity);


            GameObject childObj = new GameObject();
            //Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
            
            //Make block to be parent of this gameobject
            childObj.transform.parent = abc.transform;
            childObj.name = "Text Holder";

            //Create TextMesh and modify its properties
            TextMesh textMesh = childObj.AddComponent<TextMesh>();
            textMesh.text = RandomString();
            //textMesh.tag = "Random Text";
            ////Set postion of the TextMesh with offset
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.alignment = TextAlignment.Center;
            textMesh.transform.position = abc.transform.position;
            

            yield return new WaitForSeconds(0.01f);
            spawnCount += 1;

        }
    }

}
