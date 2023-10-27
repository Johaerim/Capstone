using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public Text txtScore;
    float speed = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fadeout());
        SetScore(-200);
    }

    // Update is called once per frame
    void Update()
    {
        float amount = speed * Time.deltaTime;
        transform.Translate(Vector3.up * amount);
    }

    IEnumerator Fadeout()
    {
        yield return new WaiteForSeconds(1f);
        Color color = txtScore.color;

        for(float alpha = 1; alpha > 0; alpha -= 0.02f)
        {
            color.a = alpha;
            txtScore.color = color;

            yield return null;
        }

        Destroy(gameObject);

    }

    void SetScore(int score)
    {
       txtScore.text = score.ToString("+0; -0");

       if(score<0)
       {
        txtScore.color = Color.red;
       }
    }
}
