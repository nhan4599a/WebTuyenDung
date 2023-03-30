using System;

namespace WebTuyenDung.Enums
{
    public enum UserRole
    {
        Candidate,
        Employer,
        Admin
    }

    public static class UserRoleRepresentation
    {
        public static string GetRepresentation(this UserRole userRole)
        {
            return userRole switch
            {
                UserRole.Candidate => "Ứng viên",
                UserRole.Employer => "Nhà tuyển dụng",
                UserRole.Admin => "Quản trị viên",
                _ => throw new NotImplementedException()
            };
        }
    }
}
