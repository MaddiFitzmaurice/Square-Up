using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float spaceSpeed;
    public float starsSpeed;

    public List<SpriteRenderer> spaceSprites;
    public List<SpriteRenderer> starsSprites;

    private float spriteLength = 40.96f;

    private List<float> spaceStartPos;
    private List<float> starsStartPos;

    // Start is called before the first frame update
    void Start()
    {
        spaceStartPos = new List<float>();
        starsStartPos = new List<float>();

        // Get starting positions of each sprite in each group
        for (int i = 0; i < spaceSprites.Count;  i++)
        {
            spaceStartPos.Add(spaceSprites[i].gameObject.transform.position.x);
        }

        for (int i = 0; i < starsSprites.Count; i++)
        {
            starsStartPos.Add(starsSprites[i].gameObject.transform.position.x);
        }
    }

    void Update()
    {
        Debug.Log(spaceSprites[0].gameObject.transform.position.x + spaceStartPos[0]);

        // Move sprites and reset position to give illusion of endless scrolling
        for (int i = 0; i < spaceSprites.Count; i++)
        {
            spaceSprites[i].gameObject.transform.Translate(Vector3.right * spaceSpeed * Time.deltaTime);
            if ((spaceSprites[i].gameObject.transform.position.x - spaceStartPos[i]) > spriteLength)
            {
                spaceSprites[i].gameObject.transform.position = new Vector3(spaceStartPos[i],
                    spaceSprites[i].gameObject.transform.position.y, spaceSprites[i].gameObject.transform.position.z);
            }
        }

        for (int i = 0; i < starsSprites.Count; i++)
        {
            starsSprites[i].gameObject.transform.Translate(Vector3.right * starsSpeed * Time.deltaTime);

            if ((starsSprites[i].gameObject.transform.position.x - starsStartPos[i]) > spriteLength)
            {
                starsSprites[i].gameObject.transform.position = new Vector3(starsStartPos[i],
                    starsSprites[i].gameObject.transform.position.y, starsSprites[i].gameObject.transform.position.z);
            }
        }
    }
}
