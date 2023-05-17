using System;

namespace WebTuyenDung.Enums
{
    public enum JobPosition : byte
    {
        BA,
        BrSE,
        Developer,
        Tester,
        QC,
        QA,
        PM,
        ITSupport,
        Designer
    }

    public static class JobPositionRepresentation
    {
        public static string GetRepresentation(this JobPosition jobPosition)
        {
            return jobPosition switch
            {
                JobPosition.BA => "Business Analysist",
                JobPosition.BrSE => "Bridge Engineering",
                JobPosition.Developer => "Developer",
                JobPosition.Tester => "Tester",
                JobPosition.QC => "Quality Control",
                JobPosition.QA => "Quality Assurance",
                JobPosition.PM => "Quản trị dự án",
                JobPosition.ITSupport => "IT Support, IT Helpdesk",
                JobPosition.Designer => "Designer",
                _ => throw new NotImplementedException()
            };
        }
    }
}
