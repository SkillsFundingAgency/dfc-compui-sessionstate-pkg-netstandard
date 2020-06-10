using DFC.Compui.Cosmos.Contracts;
using DFC.Compui.Sessionstate.UnitTests.Models;
using FakeItEasy;
using System;
using Xunit;

namespace DFC.Compui.Sessionstate.UnitTests.SessionStateServiceTests
{
    [Trait("Category", "Session State Service Unit Tests")]
    public class SessionStateServiceGetTests
    {
        [Fact]
        public void SessionStateServiceGetByIdReturnsSuccess()
        {
            // arrange
            var expectedResult = A.Fake<SessionStateModel<TestSessionStateModel>>();
            var documentService = A.Fake<IDocumentService<SessionStateModel<TestSessionStateModel>>>();

            A.CallTo(() => documentService.GetByIdAsync(A<Guid>.Ignored)).Returns(expectedResult);

            var sessionStateService = new SessionStateService<TestSessionStateModel>(documentService);

            // act
            var result = sessionStateService.GetAsync(Guid.NewGuid()).Result;

            // assert
            A.CallTo(() => documentService.GetByIdAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }

        [Fact]
        public void SessionStateServiceGetByIdReturnsnullWhenNotFound()
        {
            // arrange
            SessionStateModel<TestSessionStateModel>? expectedResult = default;
            var documentService = A.Fake<IDocumentService<SessionStateModel<TestSessionStateModel>>>();

            A.CallTo(() => documentService.GetByIdAsync(A<Guid>.Ignored)).Returns(expectedResult);

            var sessionStateService = new SessionStateService<TestSessionStateModel>(documentService);

            // act
            var result = sessionStateService.GetAsync(Guid.NewGuid()).Result;

            // assert
            A.CallTo(() => documentService.GetByIdAsync(A<Guid>.Ignored)).MustHaveHappenedOnceExactly();
            A.Equals(result, expectedResult);
        }
    }
}
