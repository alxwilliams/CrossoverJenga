using System;
using System.Collections.Generic;

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



