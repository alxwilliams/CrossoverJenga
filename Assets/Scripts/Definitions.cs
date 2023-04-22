using System;
using System.Collections.Generic;

public struct GameSettings
{
    public const float SPACE_BETWEEN_PIECES = .7f;
    public const float CAMERA_SPIN_CAP= 280;
    public const float DESCRIPTION_TEXT_DISAPPEAR_LENGTH= 6f;
}
public struct Grades
{
    public const string SIXTH_GRADE = "6th Grade";
    public const string SEVENTH_GRADE = "7th Grade";
    public const string EIGH_GRADE = "8th Grade";
}

[Serializable]
public class AllPieces
{
    public List<PieceData> list;
}
[Serializable]
public class PieceData
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
}



