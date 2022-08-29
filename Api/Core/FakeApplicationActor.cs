using Application;

namespace Api.Core
{
    public class FakeApplicationActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Test user";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1 };
    }

    public class AdminFakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "Fake Admin";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
    }
}
