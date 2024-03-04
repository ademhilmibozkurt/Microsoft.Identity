using Microsoft.AspNetCore.Identity;

namespace Identity.CustomDescriber
{
    public class CustomErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $" {userName} zaten kullanılmaktadır!"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = $"Şifre en az {length} karakter olmalıdır!"
            };
        }

        public override IdentityError PasswordRequiresLower()
        {
            return new()
            {
                Code = "PasswordRequiresLower",
                Description = "Şifre en az bir küçük hark('a'-'z') içermelidir!"
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new()
            {
                Code = "PasswordRequiresUpper",
                Description = "Şifre en az bir büyük hark('A'-'Z') içermelidir!"
            };
        }

        public override IdentityError PasswordMismatch()
        {
            return new()
            {
                Code = "PasswordMismatch",
                Description = "Girdiğiniz şifreler uyuşmuyor!"
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Şifre en az bir alfanumerik olmayan(~,!,?,* vs.) karakter içermelidir!"
            };
        }

    }
}
