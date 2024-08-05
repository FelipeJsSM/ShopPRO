using ShopPRO.Modules.Domain.Entities;
using ShopPRO.Modules.Persistence.Context;

namespace ShopPRO.Modules.Persistence.Extentions
{
    public static class TestsExtentions
    {
        public static Tests ValidateTestsExists(this ShopContext context, string testid)
        {
            var tests = context.Tests.Find(testid);
            return tests;
        }
    }
}
