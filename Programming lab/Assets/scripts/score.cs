using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public static score scoresScriptInstance;
    public TextMesh TextMesh;

    public int scoreNumber;

    private void Awake()
    {
        if(scoresScriptInstance == null)
        {
            scoresScriptInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        TextMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh.text = "score:" + scoreNumber;
    }
}
