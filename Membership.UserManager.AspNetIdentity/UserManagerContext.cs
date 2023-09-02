namespace Membership.UserManager.AspNetIdentity;
internal class UserManagerContext : IdentityDbContext<User>
{
    readonly AspnetIdentityOptions Options;
    public UserManagerContext(IOptions<AspnetIdentityOptions> options)
    {
        Options = options.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Options.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }
}
