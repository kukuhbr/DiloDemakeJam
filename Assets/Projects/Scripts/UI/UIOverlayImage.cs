using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIOverlayImage : MonoBehaviour
{
    [SerializeField] GameObject imagePrefab;
    [SerializeField] List<SpriteSequence> spriteSequences;
    //private Image image;
    void Awake()
    {
        //image = GetComponentInChildren<Image>();
        GameState.OnGameStart += OnGameStartHandler;
        GameState.OnRaceStart += OnRaceStartHandler;
        LapManager.OnLapReached += OnLapReachedHandler;
        GameState.OnRaceEnd += OnRaceEndHandler;
        GameState.OnGameEnd += OnGameEndHandler;
    }

    public void StartSequence(string name) {
        Debug.Log("start sequence" + name);
        SpriteSequence ss = GetSpriteSequence(name);
        StartCoroutine(StartSequenceCoroutine(ss));
    }

    IEnumerator StartSequenceCoroutine(SpriteSequence ss) {
        Debug.Log("In coroutine");
        yield return new WaitForSeconds(ss.delay);
        GameObject obj = Instantiate(imagePrefab, transform);
        Image image = obj.GetComponent<Image>();
        foreach (Sprite sprite in ss.sprites) {
            image.sprite = sprite;
            image.color = Color.white;
            image.transform.localScale = Vector3.one * .6f;
            float elapsedTime = 0;
            while (elapsedTime < ss.duration) {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / ss.duration;
                image.color = Color.Lerp(Color.white, new Color(1,1,1,0), t);
                // Lerp scale
                image.transform.localScale = Vector3.Lerp(Vector3.one * .6f, Vector3.one, t);
                yield return null;
            }
            yield return new WaitForSeconds(ss.interval);
        }
        Destroy(obj);
        Debug.Log("Coroutine end");
    }

    SpriteSequence GetSpriteSequence(string name) {
        foreach (SpriteSequence ss in spriteSequences) {
            if (ss.name == name) return ss;
        }
        return null;
    }

    void OnGameStartHandler()
    {
        StartSequence("GameStarted");
    }

    void OnRaceStartHandler()
    {
        StartSequence("RaceStarted");
    }

    void OnLapReachedHandler()
    {
        StartSequence("LapReached");
    }

    void OnRaceEndHandler()
    {
        //StartSequence("RaceEnded");
    }

    void OnGameEndHandler()
    {
        //StartSequence("GameEnd");
    }

    void OnDestroy()
    {
        GameState.OnGameStart -= OnGameStartHandler;
        GameState.OnRaceStart -= OnRaceStartHandler;
        LapManager.OnLapReached -= OnLapReachedHandler;
        GameState.OnRaceEnd -= OnRaceEndHandler;
        GameState.OnGameEnd -= OnGameEndHandler;
    }
}

[Serializable]
public class SpriteSequence {
    public string name;
    public float duration;
    public float interval;
    public float delay;
    public Sprite[] sprites;
}
