using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float spaceSpeed;
    public float starsSpeed;

    public List<SpriteRenderer> spaceSprites;
    public List<SpriteRenderer> starsSprites;

    private float spaceLength;
    private float starsLength = 40.96f;

    private float spaceStartPos;
    private float starsStartPos;

    // Start is called before the first frame update
    void Start()
    {
        spaceLength = spaceSprites[0].sprite.bounds.size.x;
        //starsLength = starsSprites[0].sprite.bounds.size.x;

        spaceStartPos = spaceSprites[0].gameObject.transform.position.x;
        starsStartPos = starsSprites[0].gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SpriteRenderer sprite in spaceSprites)
        {
            sprite.gameObject.transform.Translate(Vector3.right * spaceSpeed * Time.deltaTime);

            if (sprite.gameObject.transform.position.x > spaceLength)
            {
                sprite.gameObject.transform.position = new Vector3(sprite.gameObject.transform.position.x - spaceLength * 2,
                    sprite.gameObject.transform.position.y, sprite.gameObject.transform.position.z);
            }
        }

        foreach (SpriteRenderer sprite in starsSprites)
        {
            sprite.gameObject.transform.Translate(Vector3.right * starsSpeed * Time.deltaTime);

            if (sprite.gameObject.transform.position.x > starsLength)
            {
                sprite.gameObject.transform.position = new Vector3(sprite.gameObject.transform.position.x - starsLength * 2,
                    sprite.gameObject.transform.position.y, sprite.gameObject.transform.position.z);
            }
        }
    }
}
