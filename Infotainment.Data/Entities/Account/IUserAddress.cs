namespace Infotainment.Data.Entities
{
     public interface IUserAddress
    {
         System.String AddressID { get; set; }
         System.Int64 UserID { get; set; }
         System.String CareOf { get; set; }
         System.String Address1 { get; set; }
         System.String Address2 { get; set; }
         System.String City { get; set; }
         System.String State { get; set; }
         System.String Country { get; set; }
         System.String MobileNo { get; set; }
         System.String PhoneNo { get; set; }
         System.DateTime DttmCreated { get; set; }
         System.DateTime DttmModified { get; set; }
    }
}