using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Sessionstate.UnitTests.Models;
using FakeItEasy;
using System;
using Xunit;

namespace DFC.Compui.Sessionstate.UnitTests.SessionStateServiceTests
{
    [Trait("Category", "Session State Service Unit Tests")]
    public class SessionStateServiceDeleteTests
    {
        [Fact]
        public void SessionStateServiceDeleteReturnsSuccess()
        {
            // arrange
            const bool expectedResult = true;
            var documentService = A.Fake<IDocumentService<SessionStateModel<TestSessionStateModel>>>();

            A.CallTo(() => documentService.DeleteAsync(A<Guid>.Ignored)).Returns(expectedResult);

            var sessionStateService = new SessionStateService<TestSessionStateModel>(documentService);

            // act
            var result = sessionStateService.DeleteAsync(Guid.NewGuid()).Result;

            // assert
            A.CallTo(() => documentService.DeleteAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }
    }
}
