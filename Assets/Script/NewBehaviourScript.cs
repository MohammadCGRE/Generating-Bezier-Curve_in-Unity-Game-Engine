// Making Bezier Curve Code
//if you have any questions please let me know.
//s.Mohammad Moulaeifard
//Mohammad.Moulaeifard@cgre.rwth-aachen.de


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




public class NewBehaviourScript : MonoBehaviour
{
    public Transform MotherCRPoints;
    private List<Vector3> CRpointsPOS;
    public int Num;
    public LineRenderer MainCurve;
    private Vector3[] PositionsOnCurve;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        MainCurve.positionCount = Num;
        MakingListOfPoints();

        CalculateCurvePoints();

    }


    public void MakingListOfPoints()
    {
        CRpointsPOS = new List<Vector3>();
        for (int i = 0; i < MotherCRPoints.childCount; i++)
        {
            CRpointsPOS.Add(MotherCRPoints.GetChild(i).position);

        }

    }


     public Vector3 CalCurve(float t, List<Vector3> PointPos)
    {
        int i = 0;// this is the i in the equation
        Vector3 Resultt = new Vector3(0f, 0f, 0f);
        for (int j = 0; j < PointPos.Count; j++)// pointpos.count=n+1
        {


            float BinominalCoef = 1;

            if (i != 0)
            {

                for (int kk = 1; kk <= i; kk++)
                {
                    BinominalCoef *= (PointPos.Count - 1) - (i - kk);
                    BinominalCoef /= kk;

                }
            }
           
            Resultt = Resultt + BinominalCoef * (float)Math.Pow((1 - t), (PointPos.Count - 1 - i)) * (float)Math.Pow(t, i) * PointPos[i];


            i = i + 1;


        }

        return Resultt;


    }


    public void CalculateCurvePoints()
    {


        PositionsOnCurve = new Vector3[Num];

        for (int i = 0; i < Num; i++)

        {

            float t = i / (float)(Num - 1);




            PositionsOnCurve[i] = CalCurve(t, CRpointsPOS);

        }
        MainCurve.SetPositions(PositionsOnCurve);

    }




}
