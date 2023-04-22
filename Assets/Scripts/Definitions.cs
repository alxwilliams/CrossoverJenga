using System;
using System.Collections.Generic;

public struct Grades
{
    public const string SIXTH_GRADE = "6th Grade";
    public const string SEVENTH_GRADE = "7th Grade";
    public const string EIGH_GRADE = "8th Grade";
}

[Serializable]
public class AllPieces
{
    public List<JengaPiece> list;
}
[Serializable]
public class JengaPiece
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



