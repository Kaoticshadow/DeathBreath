using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject DeathText;
    public GameObject BreathText;
    public GameObject Flame1;
    public GameObject Flame2;
    public float Speed;

    Transform _flame1;
    Transform _flame2;

    void Start()
    {
        _flame1 = Flame1.transform;
        _flame2 = Flame2.transform;
        DeathText.SetActive(true);
    }

	void Update () {

        _flame1.position = Vector3.Lerp(_flame1.position,
                                        new Vector3(-4.0f, _flame1.position.y, 0), 
                                        Time.deltaTime * Speed);

        if (_flame1.position.x >= -7.0f)
        {
            _flame2.position = Vector3.Lerp(_flame2.position,
                                            new Vector3(-4.0f, _flame2.position.y, 0),
                                            Time.deltaTime * Speed);
        }

        if (_flame2.position.x >= -5.0f)
        {
            BreathText.gameObject.SetActive(true);
        }
	}
}
