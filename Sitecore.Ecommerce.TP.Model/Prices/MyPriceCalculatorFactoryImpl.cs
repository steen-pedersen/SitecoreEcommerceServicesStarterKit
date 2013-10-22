using Sitecore.Diagnostics;
using Sitecore.Ecommerce.DomainModel.Prices;
using Sitecore.Ecommerce.Security;
using Sitecore.Security.Accounts;

namespace Sitecore.Ecommerce.TP.Model.Prices
{
    public class MyPriceCalculatorFactoryImpl : PriceCalculatorFactory
    {
        // Fields
    private const string MemberPrice = "MemberPrice";
    private readonly CustomerMembership membership;
    private const string NormalPrice = "NormalPrice";
    private readonly TotalsFactory totalsFactory;

    // Methods
    public MyPriceCalculatorFactoryImpl(CustomerMembership membership, TotalsFactory totalsFactory)
    {
        Assert.ArgumentNotNull(membership, "membership");
        Assert.ArgumentNotNull(totalsFactory, "totalsFactory");
        this.membership = membership;
        this.totalsFactory = totalsFactory;
    }

    public override PriceCalculator CreateCalculator()
    {
        Assert.IsNotNull(this.User, "User cannot be null.");
        return new MyPriceCalculator(this.membership.IsCustomer(this.User) ? "MemberPrice" : "NormalPrice", this.totalsFactory);
    }

    // Properties
    protected CustomerMembership Membership
    {
        get
        {
            return this.membership;
        }
    }

    protected TotalsFactory TotalsFactory
    {
        get
        {
            return this.totalsFactory;
        }
    }

    public User User { get; set; }

    }
}
