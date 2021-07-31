using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSaveSystem
{
    private const string FileName = "BallPositionJson";
    private readonly string Path = Application.persistentDataPath + "/" + FileName;
    public void SavePosition(BallContainer container)
    {
        var json = JsonUtility.ToJson(container);

        using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
        {
            sw.WriteLine(json);
        }

    }

    public BallContainer LoadPosition()
    {
        BallContainer ballContainer;

        try
        {
            using (StreamReader sr = new StreamReader(Path))
            {
                ballContainer = JsonUtility.FromJson<BallContainer>(sr.ReadToEnd());
            }
            Debug.Log(ballContainer.BallPositions[0].Rotation + " - Pos");
            return ballContainer;
        }
        catch
        {
            return new BallContainer();
        }
    }

    public void ClearPosition()
    {
        var json = JsonUtility.ToJson(new BallContainer());
        using (StreamWriter sw = new StreamWriter(Path, false, System.Text.Encoding.Default))
        {
            sw.WriteLine(json);
        }
    }



}
