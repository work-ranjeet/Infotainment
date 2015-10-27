namespace Infotainment.Data.Entities
{
     public interface IUserEmail
    {
         System.String EmailID { get; set; }
         System.Int64 UserID { get; set; }
         System.String Email { get; set; }
         System.Int32 IsActive { get; set; }
         System.Int32 IsVerified { get; set; }
         System.Int32 IsVerCodeSent { get; set; }
         System.String VerificationCode { get; set; }
         System.DateTime DttmCreated { get; set; }
         System.DateTime DttmModified { get; set; }
    }
}