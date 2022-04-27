using PTA.Contracts.Entities.Result;
using System.Linq;
using Xunit;

namespace PTA.TestBase
{
    public class TestBase
    {
        protected TestBase()
        { }

        public static void ShouldReturnFailureWithErrorMessage<T>(
            OperationResult<T> result, string summary, string message)
        {
            result.Success.IsFalse();
            result.Value.IsNull();
            result.Errors.ErrorMessage.Is(summary);
            result.Errors.Errors.Length.Is(1);
            result.Errors.Errors.Single().Message.Is(message);
        }

        public static void ShouldReturnFailureWithErrorMessage(
            BaseOperationResult result, string summary, string message)
        {
            result.Success.IsFalse();
            result.Errors.ErrorMessage.Is(summary);
            result.Errors.Errors.Length.Is(1);
            result.Errors.Errors.Single().Message.Is(message);
        }

        public static void ShouldReturnSuccess(BaseOperationResult result)
        {
            result.Success.Is(x => x,
                $"Expected success, actual Failure, " +
                $"{result.Errors?.Errors?.FirstOrDefault().Message}");
            result.Errors.IsNull();
        }

        public static void ShouldReturnSuccess<T>(OperationResult<T> result)
        {
            result.Success.IsTrue();
            result.Value.IsInstanceOf<T>();
            result.Errors.IsNull();
        }

        public static void ShouldReturnSuccess<T, R>(OperationResult<T> result)
        {
            result.Success.IsTrue();
            result.Value.IsInstanceOf<R>();
            result.Errors.IsNull();
        }

        public static void ShouldBeGreaterThanZero(int itemId)
        {
            itemId.Is(x => x > 0, "Identifier should be greater than 0.");
        }

        public static void ShouldBeEqualArrays<T>(T[] expected, T[] current)
        {
            Enumerable.SequenceEqual(expected, current)
                .Is(x => x, $"Arrays are not equal, {expected} != {current}");
        }

        public static void ShouldBeEmptyArray<T>(T[] expected)
        {
            expected.IsNotNull();
            expected.Any().IsFalse();
        }
    }
}
