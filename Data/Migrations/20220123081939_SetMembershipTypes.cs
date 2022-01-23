using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApp.Data.Migrations
{
    public partial class SetMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name ,SignUpFee, DurationInMonths, DiscountRate ) VALUES (1,'Pay as You Go',1,1,1)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name ,SignUpFee, DurationInMonths, DiscountRate ) VALUES (2,'Monthly',2,2,2)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name ,SignUpFee, DurationInMonths, DiscountRate ) VALUES (3,'Quaterly',3,3,3)");
            migrationBuilder.Sql("INSERT INTO MembershipTypes (Id, Name ,SignUpFee, DurationInMonths, DiscountRate ) VALUES (4,'Yearly',4,4,4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
