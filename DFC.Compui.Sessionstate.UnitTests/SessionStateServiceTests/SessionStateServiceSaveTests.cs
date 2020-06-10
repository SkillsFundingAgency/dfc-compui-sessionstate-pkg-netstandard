using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Sessionstate.UnitTests.Models;
using FakeItEasy;
using System.Net;
using Xunit;

namespace DFC.Compui.Sessionstate.UnitTests.SessionStateServiceTests
{
    [Trait("Category", "Session State Service Unit Tests")]
    public class SessionStateServiceSaveTests
    {
        [Fact]
        public void SessionStateServiceSaveReturnsSuccess()
        {
            // arrange
            const HttpStatusCode expectedResult = HttpStatusCode.Created;
            var documentService = A.Fake<IDocumentService<SessionStateModel<TestSessionStateModel>>>();

            A.CallTo(() => documentService.UpsertAsync(A<SessionStateModel<TestSessionStateModel>>.Ignored)).Returns(expectedResult);

            var sessionStateService = new SessionStateService<TestSessionStateModel>(documentService);

            // act
            var result = sessionStateService.SaveAsync(A.Fake<SessionStateModel<TestSessionStateModel>>()).Result;

            // assert
            A.CallTo(() => documentService.UpsertAsync(A<SessionStateModel<TestSessionStateModel>>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }
    }
}
