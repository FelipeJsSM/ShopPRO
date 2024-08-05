using ShopPRO.Modules.Application.Core;
using ShopPRO.Modules.Application.Dtos.Tests;

namespace ShopPRO.Modules.Application.Interfaces
{
    public interface ITestsService
    {
        ServiceResult GetTests();
        ServiceResult GetTest(string id);
        ServiceResult RemoveTests(TestsRemoveDto testsRemove);
        ServiceResult SaveTests(TestsSaveDto testsSave);
    }
}
