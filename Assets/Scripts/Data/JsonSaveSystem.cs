using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaveSystem
{
    private readonly string Path = Application.persistentDataPath + "/" + Constants.BallPositionJsonFileName;
    public void SavePosition(BallContainer container)
    {
        var json = JsonUtility.ToJson(container);

        using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
        {
            sw.WriteLine(json);
        }

    }

    public BallContainer LoadPosition(DefautBallPositions defautPositions)
    {
        BallContainer ballContainer;

        try
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                ballContainer = JsonUtility.FromJson<BallContainer>(sr.ReadToEnd());
            }

            return ballContainer;
        }
        catch
        {
            return new BallContainer(defautPositions.GetRandomJsonPosition());
        }
    }

    public void SetDefaultBallPosition(DefautBallPositions defautPositions)
    {
        var json = JsonUtility.ToJson(new BallContainer(defautPositions.GetRandomJsonPosition()));

        using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
        {
            sw.WriteLine(json);
        }
    }



}
