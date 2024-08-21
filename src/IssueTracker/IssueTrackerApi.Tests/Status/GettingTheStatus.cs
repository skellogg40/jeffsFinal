

using Alba;
using IssueTracker.Shared;
using IssueTrackerApi.Controllers;

namespace IssueTrackerApi.Tests.Status;
public class GettingTheStatus
{
    [Fact]
    public async Task CurrentStatus()
    {

        var expectedResponse = new StatusResponseModel
        {
            Message = "Looks Good Here, Boss!",
            SupportContact = new SupportContactResponseModel
            {
                EMail = "franco@company.com",
                Phone = "555-1212"
            }
        };
        var host = await AlbaHost.For<global::Program>(config =>
        {
            config.ConfigureServices(sp =>
            {
                //sp.AddScoped<ILookupSupportInfo, FakeSupportLookup>();
            });
        });

        var httpResponse = await host.Scenario(api =>
         {
             api.Get.Url("/status");
             api.StatusCodeShouldBeOk();
         });

        var representation = await httpResponse.ReadAsJsonAsync<StatusResponseModel>();

        Assert.NotNull(representation);

        Assert.Equal(expectedResponse, representation);
    }

}


public class FakeSupportLookup : ILookupSupportInfo
{
    public async Task<SupportContactResponseModel> GetCurrentSupportInfoAsync()
    {

        return new SupportContactResponseModel
        {
            EMail = "franco@company.com",
            Phone = "555-1212"
        };
    }
}