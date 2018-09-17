using System;

public class uspGetReportDetailsBE
{
    public int ReportID { get; set; }
    public string ReportDesc { get; set; }
    public DateTime ReportDate { get; set; }
    public string ReportCreator { get; set; }
    public bool Processed { get; set; }
    public int? ReportTypeID { get; set; }
    public string PersonnelID { get; set; }
    public string LicensePlate { get; set; }
}