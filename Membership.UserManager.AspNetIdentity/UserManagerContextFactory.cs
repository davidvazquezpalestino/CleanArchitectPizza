namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerContextFactory :
    IDesignTimeDbContextFactory<UserManagerContext>
{
    public UserManagerContext CreateDbContext(string[] args) =>
        new UserManagerContext(
            Options.Create(new AspnetIdentityOptions
            {
                ConnectionString =
                "Server=(localdb)\\mssqllocaldb;database=MembershipDBUsersCA"
            }
            ));
}
