using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private int score = 0;

    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI congratulationsText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        congratulationsText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(int value)
    {
        score += value;

        scoreText.text = "Score: " + score;
    }

    IEnumerator CongratulationsRoutine(int level)
    {
        congratulationsText.text = "Congratulations!\nLevel " + level + " Complete!!";
        congratulationsText.gameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        GameManager.Instance.Load(0);
    }

    public void Congratulations(int level)
    {
        StartCoroutine(CongratulationsRoutine(level));
    }
}
