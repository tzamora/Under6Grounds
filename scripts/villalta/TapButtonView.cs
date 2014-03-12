using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TapButtonView : MonoBehaviour
{
    private int _currentTapCounter = 0;

    private int _previousTapCounter = 0;

    private bool _firstTap = false;

    private float _distanceFromLastTap = 0;

    private bool newTapDetected;

    private List<float> laps;

    public Vector3 MaxScale;

    public Vector3 MinScale;

    private tk2dUIItem TapButton;
    // Use this for initialization
    void Start()
    {
        TapButton = GetComponent<tk2dUIItem>();

        TapButton.OnClick += TapButtonClickHandler;

        laps = new List<float>();
    }

    void TapButtonClickHandler()
    {
        _currentTapCounter++;

        ///Debug.Log("Click #" + _currentTapCounter);

        //
        // detect the first tap
        //

        if (!_firstTap)
        {
            _firstTap = true;

            StartCoroutine(BeginClickLoop());
        }
    }

    IEnumerator BeginClickLoop()
    {
        yield return StartCoroutine(DetectTap());

        Debug.Log("first click ready");

        yield return StartCoroutine(DetectTap());

        Debug.Log("Second click ready GO!");

        yield return StartCoroutine(BeginGame());
    }

    IEnumerator DetectTap()
    {
        while (true)
        {
            if (_previousTapCounter != _currentTapCounter)
            {
                _previousTapCounter = _currentTapCounter;

                //
                // reset the time
                //

                AddLap();

                _distanceFromLastTap = 0;

                break;
            }

            _distanceFromLastTap += Time.deltaTime;

            yield return null;

            /*Debug.Log(_distanceFromLastTap);
            if (laps.Count > 0)
            {
                if (_distanceFromLastTap > laps[_currentTapCounter - 1])
                {
                    Debug.Log("LOST!!");

                    break;
                }
            }*/
        }
    }

    IEnumerator BeginGame()
    {
        while (true)
        {
            _distanceFromLastTap += Time.deltaTime;

            //
            // set the scale of the image based on the diference 
            // between the current time and the last lap
            //

            //float currentScale = _distanceFromLastTap / laps[laps.Count - 1];

            //this.transform.localScale = this.transform.localScale * currentScale;

            if (_distanceFromLastTap > laps[laps.Count-1])
            {
                Debug.Log("lost");

                break;
            }

            if (_previousTapCounter != _currentTapCounter)
            {
                _previousTapCounter = _currentTapCounter;

                //
                // reset the time
                //

                AddLap();

                _distanceFromLastTap = 0;

                //break;
            }

            yield return null;
        }


    }

    public void AddLap()
    {
        laps.Add(_distanceFromLastTap);

        Debug.Log("Good!! t minus " + _distanceFromLastTap + "laps" + laps.ToString());

        /*for (int i  =0; i<laps.Count; i++)
        {
            Debug.Log(string.Format("lap #{0} = {1}",i,laps[i]));
        }*/
    }
}
