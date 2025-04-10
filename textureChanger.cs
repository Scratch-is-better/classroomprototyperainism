using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class textureChanger : MonoBehaviour
{

    public Texture note1;
    public Texture note2;
    public Texture note3;
    public Texture note4;
    public Texture note5;
    public Texture note6;
    public Texture note7;
    public Material noteMaterial;
    bool running = false;
    

    // Start is called before the first frame update
    void Start()
    {

        List<Texture> notes = new List<Texture>() { note1, note2, note3, note4, note5, note6, note7 };
        noteMaterial.mainTexture = notes[Random.Range(0, 7)];
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = GameManager.Instance;

        gameManager.noteTexName = noteMaterial.mainTexture.name;
        List<Texture> notes = new List<Texture>() { note1, note2, note3, note4, note5, note6, note7 };


        if (gameManager.correct)
        {
            
            noteMaterial.mainTexture = notes[Random.Range(0, 7)];

            gameManager.correct = false;

        }   
    }


    IEnumerator start()
    {
        running = true;
        if (noteMaterial.mainTexture != note2) noteMaterial.mainTexture = note2;

        yield return new WaitForSeconds(2);

        if (noteMaterial.mainTexture != note1) noteMaterial.mainTexture = note1;

        yield return new WaitForSeconds(2);

        running = false;

    }

    public class DynamicVariables
    {
        public static Dictionary<string, T> CreateDynamicVariables<T>(Texture note, List<T> values)
        {
            Dictionary<string, T> dynamicVariables = new Dictionary<string, T>();
            
            for (int i = 7; i < values.Count; i++)
            {
                // Texture note = $"{baseName}{i + 1}";
                // dynamicVariables[note] = values[i];
            }

            return dynamicVariables;
        }
    }
}