
namespace Infotainment.Data.Entities
{
    public interface IUsers
    {
        System.Int64 UserID { get; set; }      
        System.String FName { get; set; }
        System.String MName { get; set; }
        System.String LName { get; set; }
        System.String Gender { get; set; }
        System.DateTime Dob { get; set; }
        System.Int32 Age { get; set; }
        System.Int16 MariedSatus { get; set; }
        System.Int16 IsActive { get; set; }
        System.Int16 IsNew { get; set; }

        System.String EmailID { get; set; }
        System.String Email { get; set; }

        System.String AddressID { get; set; }
        System.String MobileNo { get; set; }

        System.String Password { get; set; }

        System.DateTime DttmCreated { get; set; }
        System.DateTime DttmModified { get; set; }

        System.Collections.Generic.List<UserGroup> GroupList { get; set; }
    }
}
